﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.MediatR.Queries.Exercises.Extensions
{
    public static class ExercisesConfiguration
    {
        public static IServiceCollection AddExerciseMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration

            services.AddMediatR(typeof(GetAllExerciseMuscleGroupsQueryHandler));
            services.AddMediatR(typeof(GetAllExerciseTypesQueryHandler));
            services.AddMediatR(typeof(GetAllExercisesQueryHandler));

            return services;
        }
    }
}
