using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.Authentication;
using PowerBuddy.MediatR.Queries.Metrics;
using PowerBuddy.MediatR.Queries.Quotes.Extensions;
using PowerBuddy.MediatR.Queries.TemplatePrograms.Extensions;
using PowerBuddy.MediatR.Queries.Users;
using PowerBuddy.MediatR.Queries.Workouts;

namespace PowerBuddy.MediatR.Queries
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatrQueryHandlers(this IServiceCollection services)
        {
            services.AddAuthenticationMediatrHandlers();
            services.AddQuoteMediatrHandlers();
            services.AddLiftingStatsMediatrHandlers();
            services.AddTemplateMediatrHandlers();
            services.AddUserMediatrHandlers();
            services.AddWorkoutMediatrHandlers();
            services.AddAuthentication();
            return services;
        }
    }
}
