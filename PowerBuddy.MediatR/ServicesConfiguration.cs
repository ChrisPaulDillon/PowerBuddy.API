using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Emails;
using PowerBuddy.MediatR.Exercises.Querys.Admin;
using PowerBuddy.MediatR.Exercises.Querys.Public;
using PowerBuddy.MediatR.LiftingStats.Commands.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Public;
using PowerBuddy.MediatR.Metrics.Querys;
using PowerBuddy.MediatR.ProgramLogDays.Commands.Account;
using PowerBuddy.MediatR.ProgramLogDays.Querys.Account;
using PowerBuddy.MediatR.ProgramLogRepSchemes.Commands;
using PowerBuddy.MediatR.ProgramLogs.Commands;
using PowerBuddy.MediatR.ProgramLogs.Querys;
using PowerBuddy.MediatR.ProgramLogWeeks.Commands;
using PowerBuddy.MediatR.Quotes.Commands;
using PowerBuddy.MediatR.Quotes.Querys;
using PowerBuddy.MediatR.TemplatePrograms.Commands;
using PowerBuddy.MediatR.TemplatePrograms.Querys;
using PowerBuddy.MediatR.Users;
using PowerBuddy.MediatR.WorkoutDays.Commands;
using PowerBuddy.MediatR.WorkoutDays.Querys;
using PowerBuddy.MediatR.WorkoutExercises.Commands;
using PowerBuddy.MediatR.Workouts.Commands;
using PowerBuddy.MediatR.Workouts.Querys;
using PowerBuddy.MediatR.WorkoutSets.Commands;
using PowerBuddy.Services.ProgramLogs.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;

namespace PowerBuddy.MediatR
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatrHandlers(this IServiceCollection services, string baseUrl, string siteName)
        {
            services.AddProgramLogDayMediatrHandlers();
            services.AddProgramLogMediatrHandlers();
            services.AddProgramLogWeekMediatrHandlers();
            services.AddProgramLogRepSchemesMediatrHandlers();
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

        private static IServiceCollection AddProgramLogDayMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(MoveProgramLogDayCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetLatestWorkoutDaySummariesQueryHandler));

            return services;
        }

        private static IServiceCollection AddProgramLogRepSchemesMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogRepSchemeCollectionCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogRepSchemeCommandHandler));
            return services;
        }

        private static IServiceCollection AddProgramLogMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogFromScratchCommandHandler));
            services.AddMediatR(typeof(CreateProgramLogFromTemplateCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllProgramLogStatsQueryHandler));

            // Misc
            services.AddScoped<ICalculateWeightFactory, CalculateWeightFactory>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightIncremental>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightPercentage>();
            return services;
        }

        private static IServiceCollection AddProgramLogWeekMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(AddProgramLogWeekToLogCommandHandler));

            // QueryHandler Registration
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

        private static IServiceCollection AddWorkoutMediatrHandlers(this IServiceCollection services)
        {
            // Workout Logs Query & Command Handlers
            services.AddMediatR(typeof(CreateWorkoutLogFromTemplateCommandHandler));
            services.AddMediatR(typeof(CreateWorkoutTemplateCommandHandler));
            services.AddMediatR(typeof(DeleteWorkoutLogCommandHandler));

            services.AddMediatR(typeof(GetWorkoutWeekByDateQueryHandler));
            services.AddMediatR(typeof(GetAllWorkoutStatsQueryHandler));

            // Workout Days
            services.AddMediatR(typeof(GetWorkoutDayByIdQueryHandler));
            services.AddMediatR(typeof(CompleteWorkoutCommandHandler));
            services.AddMediatR(typeof(GetWorkoutDayIdByDateQueryHandler));
            services.AddMediatR(typeof(CreateWorkoutDayCommandHandler));

            // Workout Exercises
            services.AddMediatR(typeof(CreateWorkoutExerciseCommandHandler));
            services.AddMediatR(typeof(DeleteWorkoutExerciseCommandHandler));
            services.AddMediatR(typeof(UpdateWorkoutExerciseNotesCommandHandler));

            // Workout Sets
            services.AddMediatR(typeof(DeleteWorkoutSetCommandHandler));
            services.AddMediatR(typeof(QuickAddWorkoutSetsCommandHandler));
            services.AddMediatR(typeof(UpdateWorkoutSetCommandHandler));

            return services;
        }

        private static IServiceCollection AddMetricMediatrHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetLandingPageMetricsQueryHandler));
            return services;
        }

    }
}
