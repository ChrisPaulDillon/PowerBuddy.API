﻿using System.Collections.Generic;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Emails;
using PowerBuddy.MediatR.Exercises.Querys.Admin;
using PowerBuddy.MediatR.Exercises.Querys.Public;
using PowerBuddy.MediatR.LiftingStats.Commands;
using PowerBuddy.MediatR.LiftingStats.Querys.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Public;
using PowerBuddy.MediatR.Metrics.Querys;
using PowerBuddy.MediatR.Quotes.Commands;
using PowerBuddy.MediatR.Quotes.Querys;
using PowerBuddy.MediatR.TemplatePrograms.Commands;
using PowerBuddy.MediatR.TemplatePrograms.Querys;
using PowerBuddy.MediatR.Users;
using PowerBuddy.MediatR.Workouts;

namespace PowerBuddy.MediatR
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatrHandlers(this IServiceCollection services, string baseUrl, string siteName)
        {
            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            }).AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblies(new List<Assembly>() { Assembly.Load("PowerBuddy.MediatR") });
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            services.AddExerciseMediatrHandlers();
            services.AddQuoteMediatrHandlers();
            services.AddLiftingStatsMediatrHandlers();
            services.AddTemplateProgramMediatrHandlers();
            services.AddUserMediatrHandlers();
            services.AddWorkoutMediatrHandlers();
            services.AddMetricMediatrHandlers();
            services.AddAuthentication();

            services.AddEmailMediatrHandlers(baseUrl, siteName);

            return services;
        }

        private static IServiceCollection AddTemplateProgramMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateTemplateProgramCommandHandler));
            services.AddMediatR(typeof(CreateTemplateExerciseCollectionForTemplateCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetPersonalBestsForTemplateExercisesQueryHandler));
            services.AddMediatR(typeof(GetAllTemplateProgramsQueryHandler));
            services.AddMediatR(typeof(GetTecByTemplateProgramIdQueryHandler));
            services.AddMediatR(typeof(GetTemplateProgramByIdQueryHandler));
            services.AddMediatR(typeof(GetTemplateActivityFeedQueryHandler));
            services.AddMediatR(typeof(GetTemplateProgramsBySearchQueryHandler));
            return services;
        }

        private static IServiceCollection AddLiftingStatsMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(DeleteLiftingStatAuditCommandHandler));

            // Query Handlers
            services.AddMediatR(typeof(GetLiftingStatFeedForUserQueryHandler));
            services.AddMediatR(typeof(GetLiftingStatsByUserIdQueryHandler));
            services.AddMediatR(typeof(GetLiftingStatSummaryByExerciseIdQueryHandler));
            return services;
        }

        private static IServiceCollection AddQuoteMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(RequestQuoteCommandHandler));
            services.AddMediatR(typeof(CreateQuoteCommandHandler));
            services.AddMediatR(typeof(UpdateQuoteCommandHandler));
            services.AddMediatR(typeof(DeleteQuoteCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllQuotesQueryHandler));
            services.AddMediatR(typeof(GetQuoteByIdQueryHandler));
            return services;
        }

        private static IServiceCollection AddExerciseMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllUnapprovedExercisesQueryHandler));
            services.AddMediatR(typeof(GetAllExercisesBySportQueryHandler));
            services.AddMediatR(typeof(GetExerciseByIdQueryHandler));
            services.AddMediatR(typeof(GetAllExercisesQueryHandler));

            services.AddMediatR(typeof(GetAllExerciseMuscleGroupsQueryHandler));
            services.AddMediatR(typeof(GetAllExerciseTypesQueryHandler));

            return services;
        }

        private static IServiceCollection AddMetricMediatrHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetLandingPageMetricsQueryHandler));
            return services;
        }

    }
}
