namespace Powerlifting.Services.ServiceWrappers
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