using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.App.Repositories.System;

namespace PowerBuddy.App.Repositories
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