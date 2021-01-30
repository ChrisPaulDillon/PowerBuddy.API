using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.Authentication;
using PowerBuddy.MediatR.Queries.Users;

namespace PowerBuddy.MediatR.Queries.Metrics
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
