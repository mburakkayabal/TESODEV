using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TESODEV.Repository.Abstract;

namespace TESODEV.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, new()
    {
        private protected DbContext dbContext { get; }

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            try
            {
                dbContext.Remove(entity).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(T entity)
        {
            try
            {
                dbContext.Add(entity).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null) return dbContext.Set<T>().AsQueryable();

                return dbContext.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                dbContext.Update(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
