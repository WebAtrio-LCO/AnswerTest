using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlightManagerSimulator.DataLayer.Models;
using FlightSimulator.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerSimulator.DataLayer.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        //Database context used to get entity attachment
        private readonly FlightManagerDbContext _flightManagerDbContext;

        private readonly DbSet<TEntity> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightManagerDbContext">Db Context instanciate in the UnitOfWork</param>
        public Repository(FlightManagerDbContext flightManagerDbContext)
        {
            _flightManagerDbContext = flightManagerDbContext;
            _entities = flightManagerDbContext.Set<TEntity>();
        }

        
        /// <see cref="IRepository{T}.Delete(T)"/>
        public void Delete(TEntity entity)
        {
            //Prevent the deletion of entity which are nor attached to the context
            if (_flightManagerDbContext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
        }

        /// <see cref="IRepository{T}.DeleteById(int)"/>
        public void DeleteById(int id)
        {
            TEntity entityToDelete = FindById(id);
        }

        /// <see cref="IRepository{T}.FindById(int)"/>
        public TEntity FindById(int id)
        {
            return _entities.Find(id);
        }

        /// <see cref="IRepository{T}.Find(Entity)"/>
        public TEntity Find(TEntity entity)
        {
            return _entities.Find(entity);
        }

        /// <see cref="IRepository{T}.Insert(T)"/>
        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        /// <see cref="IRepository{T}.Get(List{Expression{Func{T, bool}}}, Func{IQueryable{T}, IOrderedQueryable{T}}, List{Expression{Func{T, object}}}, int, int)"/>
        public IList<TEntity> Get(List<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includedProperties = null,
            int? skip = null,
            int? take = null)
        {
            IQueryable<TEntity> query = _entities;

            //Include all properties
            includedProperties?.ForEach(i => { query = query.Include(i); });

            //apply all filters
            filters?.ForEach(i => { query = query.Where(i); });

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            //Paginate result
            if (skip.HasValue && take.HasValue)
            {
                query = query
                  .Skip(skip.Value)
                  .Take(take.Value);
            }
            return query.ToList();
        }

        /// <see cref="IRepository{T}.GetQueryable(List{Expression{Func{T, bool}}}, Func{IQueryable{T}, IOrderedQueryable{T}}, List{Expression{Func{T, object}}}, int, int)"/>
        public IQueryable<TEntity> GetQueryable(List<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includedProperties = null,
            int? skip = null,
            int? take = null)
        {
            return this.Get(filters, orderBy, includedProperties, skip, take).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            //Ensure entity is attached before changing her state
            if (_flightManagerDbContext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _flightManagerDbContext.Entry(entity).State = EntityState.Modified;

        }
    }
}
