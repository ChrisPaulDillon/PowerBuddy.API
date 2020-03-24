using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Entities.Model.Programs;

namespace Powerlifting.Contracts
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllInclude(Expression<Func<T, T>> expression);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}