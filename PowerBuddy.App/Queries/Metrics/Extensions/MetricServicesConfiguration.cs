﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.App.Queries.Metrics.Extensions
{
    public static class MetricServicesConfiguration
    {
        public static IServiceCollection AddMetricMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetLandingPageMetricsQueryHandler));
            return services;
        }
    }
}
