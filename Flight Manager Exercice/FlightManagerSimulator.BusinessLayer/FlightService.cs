using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FlightManagerSimulator.DataLayer;
using FlightManagerSimulator.DataLayer.DataAccess;
using FlightManagerSimulator.DataLayer.Models;
using FlightSimulator.Core.Common;

namespace FlightManagerSimulator.BusinessLayer
{
    /// <summary>
    /// Business class applying all logic regarding flight
    /// </summary>
    public class FlightService : IDisposable
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
        public FlightService(FlightManagerDbContext flightManagerDbContext)
        {
            _flightManagerDbContext = flightManagerDbContext;
            this.UnitOfWork = new UnitOfWork(_flightManagerDbContext);
        }

        /// <summary>
        /// Return all existing flight
        /// </summary>
        /// <returns>list of all existing <see cref="Flight"/> in database</returns>
        public IList<Flight> GetFlights(Flight flightCriteria, int? skip = null, int? take = null)
        {
            Repository<Flight> flightRepository = this.UnitOfWork.Repository<Repository<Flight>>();

            List<Expression<Func<Flight, bool>>> filters = BuildFlightFilters(flightCriteria);

            return flightRepository.Get(filters, null, null, skip, take);
        }

        /// <summary>
        /// Return all existing flight
        /// </summary>
        /// <returns>list of all existing <see cref="Flight"/> in database</returns>
        public IList<Flight> GetAllFlights()
        {
            Repository<Flight> flightRepository = this.UnitOfWork.Repository<Repository<Flight>>();
            return flightRepository.Get();
        }

        /// <summary>
        /// Update aiport data
        /// </summary>
        /// <param name="flight">Object to insert</param>
        /// <returns>boolean indicating the success or fail</returns>
        public bool UpdateFlight(Flight flight)
        {
            bool success = false;

            try
            {
                if (!CheckFlightData(flight))
                {
                    return success;
                }
                InitializeCalculatedProperties(flight);
                this.UnitOfWork.Repository<Repository<Flight>>().Update(flight);
                this.UnitOfWork.Save();
            }
            catch (Exception exc)
            {
                //todo log exception

                //throw the exception without loosing the stack
                throw;
            }
            return success;
        }

        /// <summary>
        /// Insert a new flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public bool InsertFlight(Flight flight)
        {
            bool success = false;

            try
            {
                if (!CheckFlightData(flight))
                {
                    return success;
                }
                InitializeCalculatedProperties(flight);
                this.UnitOfWork.Repository<Repository<Flight>>().Insert(flight);
                this.UnitOfWork.Save();
            }
            catch (Exception exc)
            {
                //todo log exception

                //throw the exception without loosing the stack
                throw;
            }
            return success;
        }

        /// <summary>
        /// Dispose method : She'll call UnitOfWork.Dispose()
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)UnitOfWork).Dispose();
        }

        /// <summary>
        /// Validate data of the airport
        /// </summary>
        /// <param name="aireport">airport to validate</param>
        /// <returns>True : the airport is valid; False : The airport is not valid</returns>
        private bool CheckFlightData(IFlight flight)
        {
            return !(
                string.IsNullOrWhiteSpace(flight.Identifier)
                || flight.DepartureAirport.Id == flight.DestinationAirport.Id
                || flight.Aircraft.Id < 0);
        }

        /// <summary>
        /// Compute Calculated properties before inserting in database
        /// </summary>
        /// <param name="flight"></param>
        private void InitializeCalculatedProperties(IFlight flight)
        {
            flight.Distance = GPSUtility.DistanceTo(flight.DepartureAirport.Latitude, flight.DepartureAirport.Longitude, flight.DestinationAirport.Latitude, flight.DestinationAirport.Longitude);

            //For the fuel consumption we assume the InFlyFuelConsumption is express in L/100km
            flight.FuelNeeded = flight.Aircraft.InTakeOffFuelConsumption + ((flight.Distance * flight.Aircraft.InTakeOffFuelConsumption) / 100);
        }

        /// <summary>
        /// Build the list of filters used to find Flight entities
        /// As this business service manage Flight entity he must know all her property.
        /// </summary>
        /// <param name="flightCriteria"></param>
        /// <returns></returns>
        private List<Expression<Func<Flight, bool>>> BuildFlightFilters(Flight flightCriteria)
        {
            List<Expression<Func<Flight, bool>>> filters = new List<Expression<Func<Flight, bool>>>();
            if (flightCriteria != null)
            {
                if (!string.IsNullOrWhiteSpace(flightCriteria.Identifier))
                    filters.Add(x => x.Identifier.Contains(flightCriteria.Identifier));

                if (flightCriteria.DepartureAirport != null)
                    filters.Add(x => x.DepartureAirport.Id == flightCriteria.DepartureAirport.Id);

                if (flightCriteria.DestinationAirport != null)
                    filters.Add(x => x.DestinationAirport.Id == flightCriteria.DestinationAirport.Id);

                if (flightCriteria.Aircraft != null)
                    filters.Add(x => x.Aircraft.Id == flightCriteria.Aircraft.Id);

                if (flightCriteria.Days > 0)
                    filters.Add(x => x.Days == flightCriteria.Days);
            }
            return filters;
        }
    }
}
