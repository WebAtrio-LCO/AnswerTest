using System;
using System.Collections.Generic;
using FlightManagerSimulator.DataLayer;
using FlightManagerSimulator.DataLayer.DataAccess;
using FlightManagerSimulator.DataLayer.Models;

namespace FlightManagerSimulator.BusinessLayer
{
    /// <summary>
    /// Business class implementing Disposable. UnitOfWork can be used in different methods, so it's not possible to dispose it effectively
    /// </summary>
    public class AirportService : IDisposable
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
        public AirportService(FlightManagerDbContext flightManagerDbContext)
        {
            _flightManagerDbContext = flightManagerDbContext;
            this.UnitOfWork = new UnitOfWork(_flightManagerDbContext);
        }

        /// <summary>
        /// Return all existing airport
        /// </summary>
        /// <returns>list of all existing <see cref="Airport"/> in database</returns>
        public IList<Airport> GetAllAirports()
        {
            Repository<Airport> airportRepository = this.UnitOfWork.Repository<Repository<Airport>>();
            return airportRepository.Get();
        }

        /// <summary>
        /// Update aiport data
        /// </summary>
        /// <param name="airport">Object to insert</param>
        /// <returns>boolean indicating the success or fail</returns>
        public bool UpdateAirport(Airport airport)
        {
            bool success = false;

            try
            {
                if (!CheckAirportData(airport))
                {
                    return success;
                }
                this.UnitOfWork.Repository<Repository<Airport>>().Update(airport);
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
        /// Insert a new airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public bool InsertAirport(Airport airport)
        {
            bool success = false;

            try
            {
                if (!CheckAirportData(airport))
                {
                    return success;
                }

                this.UnitOfWork.Repository<Repository<Airport>>().Insert(airport);
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
        private bool CheckAirportData(Airport airport)
        {
            return !string.IsNullOrWhiteSpace(airport.Name);
        }
    }
}
