using System;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Util;
using PowerBuddy.MediatR.Exercises.Commands.Account;
using PowerBuddy.MediatR.Exercises.Querys.Admin;
using PowerBuddy.MediatR.Exercises.Querys.Public;
using PowerBuddy.MediatR.LiftingStats.Commands.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Public;
using PowerBuddy.MediatR.Metrics.Querys;
using PowerBuddy.MediatR.ProgramLogDays.Commands.Account;
using PowerBuddy.MediatR.ProgramLogDays.Commands.Member;
using PowerBuddy.MediatR.ProgramLogDays.Querys.Account;
using PowerBuddy.MediatR.ProgramLogExercises.Commands.Account;
using PowerBuddy.MediatR.ProgramLogExercises.Querys.Account;
using PowerBuddy.MediatR.ProgramLogRepSchemes.Commands.Account;
using PowerBuddy.MediatR.ProgramLogs.Commands.Account;
using PowerBuddy.MediatR.ProgramLogs.Querys.Account;
using PowerBuddy.MediatR.ProgramLogWeeks.Commands.Account;
using PowerBuddy.MediatR.ProgramLogWeeks.Querys.Account;
using PowerBuddy.MediatR.Quotes.Commands.Account;
using PowerBuddy.MediatR.Quotes.Commands.Admin;
using PowerBuddy.MediatR.Quotes.Querys.Public;
using PowerBuddy.MediatR.TemplatePrograms.Commands.Admin;
using PowerBuddy.MediatR.TemplatePrograms.Querys.Account;
using PowerBuddy.MediatR.TemplatePrograms.Querys.Public;
using PowerBuddy.MediatR.Users.Commands.Account;
using PowerBuddy.MediatR.Users.Commands.Admin;
using PowerBuddy.MediatR.Users.Commands.Public;
using PowerBuddy.MediatR.Users.Querys.Account;
using PowerBuddy.MediatR.Users.Querys.Admin;
using PowerBuddy.MediatR.Users.Querys.Public;
using PowerBuddy.MediatR.WorkoutExercises.Commands;
using PowerBuddy.MediatR.Workouts.Commands;
using PowerBuddy.MediatR.Workouts.Querys;
using PowerBuddy.MediatR.WorkoutSets.Commands;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs;
using PowerBuddy.Services.ProgramLogs.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.System;
using PowerBuddy.Services.Templates;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.API.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection AddProgramLogDayMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogDayCommandHandler));
            services.AddMediatR(typeof(DeleteProgramLogDayCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogDayNotesCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogDayMemberCommandHandler));
            services.AddMediatR(typeof(MoveProgramLogDayCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllProgramLogCalendarStatsQueryHandler));
            services.AddMediatR(typeof(GetProgramLogDayByDateQueryHandler));
            services.AddMediatR(typeof(GetProgramLogDayByIdQueryHandler));
            services.AddMediatR(typeof(GetProgramSpecificDayByDateQueryHandler));
            services.AddMediatR(typeof(GetLatestWorkoutDaySummariesQueryHandler));

            return services;
        }

        public static IServiceCollection AddProgramLogExerciseMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogExerciseCommandHandler));
            services.AddMediatR(typeof(DeleteProgramLogExerciseCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogExerciseNotesCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetProgramLogExerciseByIdQueryHandler));
            return services;
        }

        public static IServiceCollection AddProgramLogRepSchemesMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogRepSchemeCollectionCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogRepSchemeCommandHandler));
            services.AddMediatR(typeof(DeleteProgramLogRepSchemeCommandHandler));
            return services;
        }

        public static IServiceCollection AddProgramLogMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogFromScratchCommandHandler));
            services.AddMediatR(typeof(CreateProgramLogFromTemplateCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogCommandHandler));
            services.AddMediatR(typeof(DeleteProgramLogCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetActiveProgramLogByUserIdQueryHandler));
            services.AddMediatR(typeof(GetAllProgramLogStatsQueryHandler));

            // Misc
            services.AddScoped<ICalculateWeightFactory, CalculateWeightFactory>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightIncremental>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightPercentage>();
            return services;
        }

        public static IServiceCollection AddProgramLogWeekMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(AddProgramLogWeekToLogCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetProgramLogWeekBetweenDateQueryHandler));
            return services;
        }

        public static IServiceCollection AddTemplateProgramMediatrHandlers(this IServiceCollection services)
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
            return services;
        }

        public static IServiceCollection AddUserMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(BanUserCommandHandler));
            services.AddMediatR(typeof(RegisterUserCommandHandler));
            services.AddMediatR(typeof(CreateFirstVisitStatsCommandHandler));
            services.AddMediatR(typeof(EditProfileCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllUsersByAdminQueryHandler));
            services.AddMediatR(typeof(GetPublicUserProfileByIdQueryHandler));
            services.AddMediatR(typeof(GetPublicUserProfileByUsernameQueryHandler));
            services.AddMediatR(typeof(LoginUserQueryHandler));
            services.AddMediatR(typeof(GetUserProfileQueryHandler));
            return services;
        }

        public static IServiceCollection AddLiftingStatsMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(DeleteLiftingStatAuditCommandHandler));

            // Query Handlers
            services.AddMediatR(typeof(GetLiftingStatFeedForUserQueryHandler));
            services.AddMediatR(typeof(GetLiftingStatsByUserIdQueryHandler));
            services.AddMediatR(typeof(GetLiftingStatByIdQueryHandler));
            return services;
        }

        public static IServiceCollection AddQuoteMediatrHandlers(this IServiceCollection services)
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

        public static IServiceCollection AddExerciseMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateExerciseCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllUnapprovedExercisesQueryHandler));
            services.AddMediatR(typeof(GetAllExercisesBySportQueryHandler));
            services.AddMediatR(typeof(GetExerciseByIdQueryHandler));
            services.AddMediatR(typeof(GetAllExercisesQueryHandler));

            return services;
        }

        public static IServiceCollection AddWorkoutMediatrHandlers(this IServiceCollection services)
        {
            // Workout Logs Query & Command Handlers
            services.AddMediatR(typeof(CreateWorkoutLogFromTemplateCommandHandler));
            services.AddMediatR(typeof(CreateWorkoutTemplateCommandHandler));
            services.AddMediatR(typeof(GetWorkoutWeekByDateQueryHandler));

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

        public static IServiceCollection AddExerciseTypeMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllExerciseTypesQueryHandler));
            return services;
        }


        public static IServiceCollection AddExerciseMuscleGroupHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllExerciseMuscleGroupsQueryHandler));
            return services;
        }

        public static IServiceCollection AddMetricMediatrHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetLandingPageMetricsQueryHandler));
            return services;
        }

        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IDTOFactory, DTOFactory>();
            return services;
        }

        public static IServiceCollection AddServiceClasses(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILiftingStatService, LiftingStatService>();
            services.AddScoped<IProgramLogService, ProgramLogService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IWorkoutService, WorkoutService>();

            return services;
        }


        public static IServiceCollection AddPowerLiftingContext(this IServiceCollection services, string connectionStr)
        {
            services.AddDbContext<PowerLiftingContext>(options =>
                options.UseSqlServer(connectionStr));

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfigurationSection corsConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")//corsConfig["Client_URL"].ToString(), "")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            return services;
        }

        public static IServiceCollection AddSentry(this IServiceCollection services, IConfigurationSection sentryConfig)
        {
            //TODO
            //services.Configure<ApplicationSettings>(applicationSettings));
            return services;
        }

        public static IServiceCollection AddJWTSettings(this IServiceCollection services, IConfigurationSection jwtSettings)
        {
            services.Configure<JWTSettings>(jwtSettings);
            services.AddSingleton(svc => svc.GetService<IOptions<JWTSettings>>().Value);
            var key = Encoding.UTF8.GetBytes(jwtSettings["JWT_Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
