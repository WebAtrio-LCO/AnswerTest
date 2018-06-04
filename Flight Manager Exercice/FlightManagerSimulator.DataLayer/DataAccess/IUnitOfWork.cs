using System;
using FlightManagerSimulator.DataLayer.Models;

namespace FlightSimulator.Core.DataAccess
{
    /// <summary>
    /// UnitOfWork interface : used to manage repsitories and save change from memory to database
    /// This interface define all methods that must be implemented by a class which implements IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save Current modifications
        /// </summary>
        void Save();

        /// <summary>
        /// Return a generic repository base on the specified entity
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <returns></returns>
        IRepository<T> GenericRepository<T>() where T : class, IBaseEntity;

        /// <summary>
        /// Return a respository implimenting IBaseRepository
        /// </summary>
        /// <typeparam name="R">Type of the repository to retrieve</typeparam>
        /// <returns>A repository which can be specific or generic </returns>
        R Repository<R>() where R : IBaseRepository;

        /// <summary>
        /// Define how resources used by any UnitOfWork class are disposed
        /// </summary>
        /// <param name="disposing">true : Dispose both managed and unmanaged ressources; false : Dispose only unmanaged ressources</param>
        void Dispose(bool disposing);

    }
}
