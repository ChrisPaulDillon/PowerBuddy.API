using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.Repositories.Exercises;
using PowerBuddy.Repositories.System;
using PowerBuddy.Services.System;

namespace PowerBuddy.Repositories
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IExerciseRepository, ExerciseRepository>();
            services.Decorate<IExerciseRepository, CachedExerciseRepository>();

            services.AddSingleton<ISystemRepository, SystemRepository>();
            services.Decorate<ISystemRepository, CachedSystemRepository>();

            return services;
        }
    }
}