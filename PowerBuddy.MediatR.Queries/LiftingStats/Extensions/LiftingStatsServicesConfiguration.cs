using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.Metrics;

namespace PowerBuddy.MediatR.Queries.LiftingStats.Extensions
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
