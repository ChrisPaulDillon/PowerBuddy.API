using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Powerlifting.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PowerliftingContext PowerliftingContext { get; set; }

        public RepositoryBase(PowerliftingContext repositoryContext)
        {
            PowerliftingContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.PowerliftingContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return PowerliftingContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            PowerliftingContext.Set<T>().Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            PowerliftingContext.Set<T>().Update(entity);
            Save();
        }

        public void Delete(T entity)
        {
            PowerliftingContext.Set<T>().Remove(entity);
            Save();
        }

        public void Save()
        {
            PowerliftingContext.SaveChanges();
        }
    }
}