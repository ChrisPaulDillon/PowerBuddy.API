using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts;
using PowerLifting.Persistence;

namespace Powerlifting.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected PowerliftingContext PowerliftingContext { get; set; }

        public ServiceBase(PowerliftingContext ServiceContext)
        {
            this.PowerliftingContext = ServiceContext;
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