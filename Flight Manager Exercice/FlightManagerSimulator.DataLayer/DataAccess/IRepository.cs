using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlightManagerSimulator.DataLayer.Models;

namespace FlightSimulator.Core.DataAccess
{
    /// <summary>
    /// Interface use for the repository fabric in the UnitOfWork class
    /// </summary>
    public interface IBaseRepository
    {
    }

    /// <summary>
    /// Generic Repository base Interface
    /// </summary>
    /// <typeparam name="T">Type of the entity to manage</typeparam>
    public interface IRepository<T> : IBaseRepository where T : IBaseEntity
    {
        /// <summary>
        /// Find an entity by her id
        /// </summary>
        /// <param name="id">Entity's Id</param>
        /// <returns>Entity found or null</returns>
        T FindById(int id);

        /// <summary>
        /// Find an entity
        /// </summary>
        /// <param name="entity">Entity to find</param>
        /// <returns>Entity found or null</returns>
        T Find(T entity);

        /// <summary>
        /// Search for a set of entity
        /// </summary>
        /// <param name="filter">List of expression which will be executed in where clause</param>
        /// <param name="orderBy">Sort methode to apply</param>
        /// <param name="includedProperties">List of expression which will be executed in include clase</param>
        /// <returns>A listof entity requested from database</returns>
        IList<T> Get(List<Expression<Func<T, bool>>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includedProperties = null,
            int? skip = null,
            int? take = null);

        /// <summary>
        /// Search for a set of entity and return an queryable object
        /// </summary>
        /// <param name="filter">List of expression which will be executed in where clause</param>
        /// <param name="orderBy">Sort methode to apply</param>
        /// <param name="includedProperties">List of expression which will be executed in include clase</param>
        /// <returns>A listof entity requested from database</returns>
        IQueryable<T> GetQueryable(List<Expression<Func<T, bool>>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includedProperties = null,
            int? skip = null,
            int? take = null);

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="entity">Entity and her data to insert in database</param>
        void Insert(T entity);

        /// <summary>
        /// Update the data of an entity
        /// </summary>
        /// <param name="entity">entity to update</param>
        void Update(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="id">Id of the entity to delete</param>
        void DeleteById(int id);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(T entity);
    }
}
