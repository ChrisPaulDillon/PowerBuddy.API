using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using PowerLifting.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powerlifting.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PowerliftingContext PowerliftingContext { get; set; }

        public RepositoryBase(PowerliftingContext repositoryContext)
        {
            this.PowerliftingContext = repositoryContext;
        }

        public async Task<IList<T>> GetAll()
        {
            return await PowerliftingContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Update(T entity)
        {
            PowerliftingContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            PowerliftingContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            PowerliftingContext.SaveChanges();
        }

        public void Create(T entity)
        {
            PowerliftingContext.Set<T>().Add(entity);
            Save();
        }

        IQueryable<T> IRepositoryBase<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}