using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.App.Queries.Exercises.Extensions
{
    public static class ExercisesConfiguration
    {
        public static IServiceCollection AddExerciseMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration

            services.AddMediatR(typeof(GetAllExerciseMuscleGroupsQueryHandler));
            services.AddMediatR(typeof(GetAllExerciseTypesQueryHandler));
            services.AddMediatR(typeof(GetAllExercisesQueryHandler));
            services.AddMediatR(typeof(GetExerciseByIdQueryHandler));

            return services;
        }
    }
}
