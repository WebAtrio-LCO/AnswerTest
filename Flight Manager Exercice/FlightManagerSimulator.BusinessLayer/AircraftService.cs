using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using FlightManagerSimulator.DataLayer;
using FlightManagerSimulator.DataLayer.DataAccess;
using FlightManagerSimulator.DataLayer.Models;

namespace FlightManagerSimulator.BusinessLayer
{
    /// <summary>
    /// Business class implementing Disposable. UnitOfWork can be used in different methods, so it's not possible to dispose it effectively
    /// </summary>
    public class AircraftService : IDisposable
    {
        /// <summary>
        /// Database context
        /// Note : In case of Depedency injection, it would be an automatic property
        /// </summary>
        private readonly FlightManagerDbContext _flightManagerDbContext;

        /// <summary>
        /// Centralize 
        /// </summary>
        public UnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor used to assign the DBContetxt to the service
        /// </summary>
        /// <param name="flightManagerDbContext">DbContext for Flight Manager Simulator</param>
        public AircraftService(FlightManagerDbContext flightManagerDbContext)
        {
            _flightManagerDbContext = flightManagerDbContext;
            this.UnitOfWork = new UnitOfWork(_flightManagerDbContext);
        }

        /// <summary>
        /// Retrieve all aircraft from database
        /// </summary>
        /// <returns></returns>
        public IList<Aircraft> GetAllAircrafts()
        {
            Repository<Aircraft> AircraftRepository = this.UnitOfWork.Repository<Repository<Aircraft>>();
            return AircraftRepository.Get();
        }

        /// <summary>
        /// Retrieve available craft for a specific day
        /// </summary>
        /// <param name="day">Requested day of week</param>
        /// <returns></returns>
        public IList<Aircraft> GetAllAvailableAircrafts(int day)
        {
            //Get All flight within the chosen day
            var FlightRepository = this.UnitOfWork.Repository<Repository<Flight>>();
            List<Expression<Func<Flight, bool>>> filters = new List<Expression<Func<Flight, bool>>>();
            filters.Add(f => f.Days == day);
            var queryableFlight = FlightRepository.GetQueryable(filters);

            //Get all the existing aircraft in queryable 
            var queryableAircraft = this.UnitOfWork.Repository<Repository<Aircraft>>().GetQueryable();

            //Request to select only aircraft which are not yet select for a flight
            return queryableAircraft.Where(a => queryableFlight.Count(f => f.Aircraft.Id == a.Id) < a.Count).ToList();
        }

        /// <summary>
        /// Update aircraft data
        /// </summary>
        /// <param name="aircraft">Object to insert</param>
        /// <returns>boolean indicating the success or fail</returns>
        public bool UpdateAircraft(Aircraft aircraft)
        {
            bool success = false;

            try
            {
                if (!CheckAircraftData(aircraft))
                {
                    return success;
                }

                this.UnitOfWork.Repository<Repository<Aircraft>>().Update(aircraft);
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
        /// Insert a new airecraft
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
        public bool InsertAircraft(Aircraft aircraft)
        {
            bool success = false;

            try
            {
                if (!CheckAircraftData(aircraft))
                {
                    return success;
                }

                this.UnitOfWork.Repository<Repository<Aircraft>>().Insert(aircraft);
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

        public void Dispose()
        {
            ((IDisposable)UnitOfWork).Dispose();
        }

        /// <summary>
        /// Validate data of the aicraft
        /// </summary>
        /// <param name="aircraft">aicraft to validate</param>
        /// <returns>True : the aicraft is valid; False : The aicraft is not valid</returns>
        private bool CheckAircraftData(Aircraft aircraft)
        {
            return !(string.IsNullOrWhiteSpace(aircraft.Name) || aircraft.Count < 0);
        }
    }
}
