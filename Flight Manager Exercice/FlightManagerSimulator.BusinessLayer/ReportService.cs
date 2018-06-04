using FlightManagerSimulator.DataLayer;
using FlightManagerSimulator.DataLayer.DataAccess;
using FlightManagerSimulator.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagerSimulator.BusinessLayer
{
    public class ReportService : IDisposable
    {
        /// <summary>
        /// Database context
        /// Note : In case of Depedency injection, it would be an automatic property
        /// </summary>
        private readonly FlightManagerDbContext _flightManagerDbContext;

        /// <summary>
        /// Manage all modifications in database
        /// </summary>
        public UnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor used to assign the DBContetxt to the service
        /// </summary>
        /// <param name="flightManagerDbContext">DbContext for Flight Manager Simulator</param>
        public ReportService(FlightManagerDbContext flightManagerDbContext)
        {
            _flightManagerDbContext = flightManagerDbContext;
            this.UnitOfWork = new UnitOfWork(_flightManagerDbContext);
        }

        /// <summary>
        /// Async : Generate the report of all statistics of flight
        /// Asynchronous on report will make the generation more responsive
        /// </summary>
        /// <returns></returns>
        public async Task<IGeneratedReport> GenerateReport()
        {
            var flightRepository = this.UnitOfWork.Repository<Repository<Flight>>();
            var flight =  flightRepository.Get();

            var computeAirportData = Task.Run(() => ComputeAirportData(flight));
            var computeAircraftData = Task.Run(() => ComputeAircraftData(flight));
            var computeFlightData = Task.Run(() => ComputeFlightData(flight));

            // wait for achievment of all statistic task 
            await Task.WhenAll(computeAirportData);

            //When all data are computed, they are assigned to the IGenerated Object
            IGeneratedReport generatedReport = computeFlightData.Result;
            generatedReport.AircraftTraffic = computeAirportData.Result;
            generatedReport.AircraftTaveledDistance = computeAircraftData.Result;
            return generatedReport;
        }

        /// <summary>
        /// Compute the number of flight by airport (departure + arrival)
        /// </summary>
        /// <param name="baseFlightReports">list of all flight</param>
        /// <returns>Dictionary with airport name and count of flight</returns>
        private Dictionary<string, int> ComputeAirportData(IList<Flight> baseFlightReports)
        {
            Dictionary<string, int> airportFlightCount = new Dictionary<string, int>();
            //create queryable object from list of flight
            var baseQueryObject = baseFlightReports.AsQueryable();

            //Compute flight count (Arrival + departure)
            var baseQueryCountFlight = from flight in baseFlightReports
                                          select flight.DepartureAirport.Name;
            var airportsNames = baseQueryCountFlight.Union(from flight in baseFlightReports
                                                                        select flight.DestinationAirport.Name);
            // Get distinct names
            var distinctAirportsNames = airportsNames.Distinct();

            //Build flight count by each unique airport
            foreach (string airportName in distinctAirportsNames)
            {
                airportFlightCount.Add(airportName, airportsNames.Count(a => a == airportName));
            }

            return airportFlightCount;
        }

        /// <summary>
        /// Compute the number of flight by airport (deperture + arrival)
        /// </summary>
        /// <param name="baseFlightReports">list of all flight</param>
        /// <returns>Dictionary with airport name and count of flight</returns>
        private Dictionary<string, double> ComputeAircraftData(IList<Flight> baseFlightReports)
        {
            var aircraftFlightCount = new Dictionary<string, double>();

            //create queryable object from list of flight
            var baseQueryObject = baseFlightReports.AsQueryable();

            //Compute flight count (Arrival + departure)
            var aircraftsFlight = from flight in baseFlightReports
                                       select new { flight.Aircraft.Name, flight.Distance };
            //Get list distinguished of aircraft's name
            var distinctAicraftsFlight = aircraftsFlight.Select(a => a.Name).Distinct();

            //Build flight count by each unique airport
            foreach (string aicraftName in distinctAicraftsFlight)
            {
                aircraftFlightCount.Add(aicraftName, aircraftsFlight.Sum(a => a.Distance));
            }

            return aircraftFlightCount;
        }

        /// <summary>
        /// Compute basic statistics on flight
        /// </summary>
        /// <param name="baseFlightReports">list of all flights</param>
        /// <returns>IGeneratedReport object containing basic statistics</returns>
        private IGeneratedReport ComputeFlightData(IList<Flight> baseFlightReports)
        {
            GeneratedReport generatedReport = new GeneratedReport();

            //count
            generatedReport.FlightCount = baseFlightReports.Count();

            //Max Distance
            generatedReport.MaximalDistance = baseFlightReports.Max(m=> m.Distance);

            //Min Distance
            generatedReport.MinimalDistance = baseFlightReports.Min(m => m.Distance);

            //Total Travel Distance
            generatedReport.TotalTraveledDistance = baseFlightReports.Sum(d => d.Distance);

            //Total Fuel needed
            generatedReport.TotalFuelNeeded = baseFlightReports.Sum(f => f.FuelNeeded);

            //Avirage flight distance
            generatedReport.AverageDistance = generatedReport.TotalTraveledDistance / generatedReport.FlightCount;
            return generatedReport;
        }

        /// <summary>
        /// Dispose method : She'll call UnitOfWork.Dispose()
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)UnitOfWork).Dispose();
        }

    }
}
