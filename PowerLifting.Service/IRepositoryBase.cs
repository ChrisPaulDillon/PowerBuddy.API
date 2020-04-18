using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PowerLifting.Service
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}