using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using StudioGlumeScena.DataAccess.Interfaces;
using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Classes
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        #region Fields

        protected readonly StudioGlumeScenaContext _context;
        private readonly IConfiguration _configuration;

        #endregion Fields

        #region Properties

        public StudioGlumeScenaContext Context
        {
            get
            {
                return _context;
            }
        }

        public IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        #endregion

        #region Constructors

        public BaseDAL(StudioGlumeScenaContext context, IConfiguration configuration)
        {
            try
            {
                _context = context;
                _configuration = configuration;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion Constructors

        #region Public methods



        void IBaseDAL<T>.Insert(T entity)
        {
            try
            {
                EntityEntry<T> savedEntity;
                savedEntity = _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void IBaseDAL<T>.Delete(T entity)
        {
            try
            {
                EntityEntry<T> deletedEntity;
                deletedEntity = _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void IBaseDAL<T>.Update(T entity)
        {
            try
            {
                EntityEntry<T> savedEntity;
                savedEntity = _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void IBaseDAL<T>.UpdateRange(List<T> entities)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        List<T> IBaseDAL<T>.GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T Get(long id)
        {
            var entity = _context.Set<T>().Find(id);
            return entity;
        }
        public IQueryable<T> GetFor(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return query;
        }


        public void SaveChanges()
        {
            _context.SaveChanges(true);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(true);
        }

        #endregion Public methods
    }
}
