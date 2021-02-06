using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.Data.Factories;

namespace PowerBuddy.Data.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IDtoFactory, DtoFactory>();

            return services;
        }
    }
}
