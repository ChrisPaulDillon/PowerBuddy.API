using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.Authentication.Extensions;
using PowerBuddy.MediatR.Queries.Exercises.Extensions;
using PowerBuddy.MediatR.Queries.LiftingStats.Extensions;
using PowerBuddy.MediatR.Queries.Metrics.Extensions;
using PowerBuddy.MediatR.Queries.Quotes.Extensions;
using PowerBuddy.MediatR.Queries.TemplatePrograms.Extensions;
using PowerBuddy.MediatR.Queries.Users.Extensions;
using PowerBuddy.MediatR.Queries.Workouts;
using PowerBuddy.Repositories;

namespace PowerBuddy.MediatR.Queries
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatrQueryHandlers(this IServiceCollection services)
        {
            services.AddAuthenticationMediatrHandlers();
            services.AddExerciseMediatrHandlers();
            services.AddMetricMediatrHandlers();
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
