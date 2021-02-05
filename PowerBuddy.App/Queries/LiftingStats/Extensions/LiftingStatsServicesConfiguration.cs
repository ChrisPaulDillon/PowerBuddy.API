using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Queries.Metrics;

namespace PowerBuddy.App.Queries.LiftingStats.Extensions
{
    public static class LiftingStatsServicesConfiguration
    {
        public static IServiceCollection AddLiftingStatsMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetLandingPageMetricsQueryHandler));
            return services;
        }
    }
}
