using System;
using System.Collections;
using FlightManagerSimulator.DataLayer.Models;
using FlightSimulator.Core.DataAccess;

namespace FlightManagerSimulator.DataLayer.DataAccess
{
    /// <summary>
    /// Centralize all interaction with the data base.
    /// This class automatically instanciate needed repository.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Database context
        /// Note : In case of Depedency injection, it would be an automatic property.
        /// </summary>
        private readonly FlightManagerDbContext _flightManagerDbContext;

        /// <summary>
        /// Indicate if the instance of UnitOfWork is disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Hastable containing all Repositories
        /// An Hashtable is used to ensure that during the UnitOfWork life cycle, only one instance of an repository is created at the same time
        /// </summary>
        private Hashtable _repositories;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="flightManagerDbContext">DbContext created </param>
        public UnitOfWork(FlightManagerDbContext flightManagerDbContext)
        {
            _flightManagerDbContext = flightManagerDbContext;
        }

        /// <see cref="IUnitOfWork.Dispose(bool)"/>
        public void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _flightManagerDbContext.Dispose();

            _disposed = true;
        }

        /// <summary>
        /// Implementation of IDisposable.Dispose
        /// Use to dispose unmanaged ressources 
        /// </summary>
        public void Dispose()
        {
            // Dispose resources used by this instance of UnitOfWork class
            this.Dispose(true);

            // When supressing the Finalizer from the Grbage Collector, The instance is cleanup without delay
            GC.SuppressFinalize(this);
        }

        /// <see cref="IUnitOfWork.GenericRepository{T}"/>
        public IRepository<T> GenericRepository<T>() where T : class, IBaseEntity
        {
            // Call the Repository Fabric
            return Repository<IRepository<T>>();
        }

        /// <see cref="IUnitOfWork.Repository{R}"/>
        public R Repository<R>() where R : IBaseRepository
        {
            
            if (_repositories == null)
                _repositories = new Hashtable();

            // get type of requested repository for HashTable use
            var type = typeof(R).Name;

            // If the repository have nor been created before
            if (!_repositories.ContainsKey(type))
            {
                //Get the type of the requested Repository : it can be a custom Repository inheriting from 
                var repositoryType = typeof(R);

                // Create the Repository instance.
                var repositoryInstance =
                  Activator.CreateInstance(repositoryType, _flightManagerDbContext);

                //Add it to the existing repositories
                _repositories.Add(type, repositoryInstance);
            }

            return (R)_repositories[type];
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
