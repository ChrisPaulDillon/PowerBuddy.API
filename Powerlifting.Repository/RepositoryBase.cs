using Powerlifting.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Entity.Entities.Data;

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

        public async Task<IList<T>> GetAllByCondition(Expression<Func<T, bool>> expression)
        {
            return await PowerliftingContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await PowerliftingContext.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await this.PowerliftingContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            PowerliftingContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            PowerliftingContext.Set<T>().Remove(entity);
        }
    }
}