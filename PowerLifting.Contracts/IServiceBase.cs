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
        void Update(T entity);
        void Delete(T entity);
    }
}