using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powerlifting.Common
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}