using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            return PowerliftingContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return PowerliftingContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task Create(T entity)
        {
            PowerliftingContext.Set<T>().Add(entity);
            await PowerliftingContext.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            PowerliftingContext.Set<T>().Update(entity);
            var modifiedRows = await PowerliftingContext.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            PowerliftingContext.Set<T>().Remove(entity);
            var modifiedRows = await PowerliftingContext.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}