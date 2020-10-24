using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerLifting.Data.Util;
using System;
using System.Text;
using PowerLifting.MediatR.Exercises.CommandHandler.Account;
using MediatR;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Factories;
using PowerLifting.MediaR.Quotes.CommandHandler.Account;
using PowerLifting.MediaR.Quotes.CommandHandler.Admin;
using PowerLifting.MediaR.Quotes.QueryHandler.Public;
using PowerLifting.MediatR.ExerciseMuscleGroups.QueryHandler.Public;
using PowerLifting.MediatR.Exercises.QueryHandler.Admin;
using PowerLifting.MediatR.Exercises.QueryHandler.Public;
using PowerLifting.MediatR.ExerciseTypes.QueryHandler.Public;
using PowerLifting.MediatR.FriendsLists.CommandHandler.Account;
using PowerLifting.MediatR.FriendsLists.QueryHandler.Account;
using PowerLifting.MediatR.LiftingStats.CommandHandler.Account;
using PowerLifting.MediatR.LiftingStats.QueryHandler.Account;
using PowerLifting.MediatR.LiftingStats.QueryHandler.Public;
using PowerLifting.MediatR.Notifications.CommandHandler.Account;
using PowerLifting.MediatR.Notifications.CommandHandler.Admin;
using PowerLifting.MediatR.Notifications.QueryHandler.Account;
using PowerLifting.MediatR.ProgramLogDays.CommandHandler.Account;
using PowerLifting.MediatR.ProgramLogDays.CommandHandler.Member;
using PowerLifting.MediatR.ProgramLogDays.QueryHandler.Account;
using PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Account;
using PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Member;
using PowerLifting.MediatR.ProgramLogExercises.QueryHandler.Account;
using PowerLifting.MediatR.ProgramLogRepSchemes.CommandHandler.Account;
using PowerLifting.MediatR.ProgramLogs.CommandHandler.Account;
using PowerLifting.MediatR.ProgramLogs.QueryHandler.Account;
using PowerLifting.MediatR.ProgramLogWeeks.CommandHandler.Account;
using PowerLifting.MediatR.ProgramLogWeeks.QueryHandler.Account;
using PowerLifting.MediatR.TemplatePrograms.CommandHandler.Admin;
using PowerLifting.MediatR.TemplatePrograms.QueryHandler.Account;
using PowerLifting.MediatR.TemplatePrograms.QueryHandler.Public;
using PowerLifting.MediatR.Users.CommandHandler.Account;
using PowerLifting.MediatR.Users.CommandHandler.Admin;
using PowerLifting.MediatR.Users.CommandHandler.Public;
using PowerLifting.MediatR.Users.QueryHandler.Account;
using PowerLifting.MediatR.Users.QueryHandler.Admin;
using PowerLifting.MediatR.Users.QueryHandler.Public;
using PowerLifting.MediatR.System.QueryHandler.Public;
using PowerLifting.Service.Account;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.ProgramLogs.Factories;
using PowerLifting.Service.ProgramLogs.Strategies;

namespace PowerLifting.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllGendersQueryHandler));
            services.AddMediatR(typeof(GetAllMemberStatusQueryHandler));
            return services;
        }


        public static IServiceCollection AddProgramLogDayMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogDayCommandHandler));
            services.AddMediatR(typeof(DeleteProgramLogDayCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogDayNotesCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogDayMemberCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllProgramLogCalendarStatsQueryHandler));
            services.AddMediatR(typeof(GetProgramLogDayByDateQueryHandler));
            services.AddMediatR(typeof(GetProgramLogDayByIdQueryHandler));
            services.AddMediatR(typeof(GetProgramSpecificDayByDateQueryHandler));
            return services;
        }

        public static IServiceCollection AddProgramLogExerciseMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateProgramLogExerciseCommandHandler));
            services.AddMediatR(typeof(DeleteProgramLogExerciseCommandHandler));
            services.AddMediatR(typeof(UpdateProgramLogExerciseMemberCommandHandler));
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
            services.AddMediatR(typeof(CreateProgramLogFromTemplateWithWeightInputCommandHandler));
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
            services.AddMediatR(typeof(DoesUserHaveExerciseCollection1RMSetQueryHandler));
            services.AddMediatR(typeof(GetAllTemplateProgramsQueryHandler));
            services.AddMediatR(typeof(GetTecByTemplateProgramIdQueryHandler));
            services.AddMediatR(typeof(GetTemplateProgramByIdQueryHandler));
            services.AddMediatR(typeof(GetTemplateProgramNameByIdQueryHandler));
            return services;
        }

        public static IServiceCollection AddUserMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(BanUserCommandHandler));
            services.AddMediatR(typeof(RegisterUserCommandHandler));
            services.AddMediatR(typeof(CreateFirstVisitStatsCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllUsersByAdminQueryHandler));
            services.AddMediatR(typeof(GetPublicUserProfileByIdQueryHandler));
            services.AddMediatR(typeof(GetPublicUserProfileByUsernameQueryHandler));
            services.AddMediatR(typeof(LoginUserQueryHandler));
            services.AddMediatR(typeof(GetUserProfileQueryHandler));
            return services;
        }

        public static IServiceCollection AddNotificationsMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(MarkNotificationReadCommandHandler));
            services.AddMediatR(typeof(CreateNotificationCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetUserNotificationsQueryHandler));
            return services;
        }

        public static IServiceCollection AddLiftingStatsMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateLiftingStatCommandHandler));
            services.AddMediatR(typeof(CreateLiftingStatsBySportsTypeCommandHandler));
            services.AddMediatR(typeof(DeleteLiftingStatCommandHandler));
            services.AddMediatR(typeof(UpdateLiftingStatCollectionCommandHandler));
            services.AddMediatR(typeof(UpdateLiftingStatCommandHandler));
            services.AddMediatR(typeof(CreateLiftingStatCollectionCommandHandler));

            // Query Handlers
            services.AddMediatR(typeof(GetLiftingStatFeedForUserQueryHandler));
            services.AddMediatR(typeof(GetLiftingStatsByUserIdQueryHandler));
            return services;
        }

        public static IServiceCollection AddFriendsListsMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(RespondToFriendRequestCommandHandler));
            services.AddMediatR(typeof(SendFriendRequestCommandHandler));

            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllPendingFriendRequestsQueryHandler));
            services.AddMediatR(typeof(GetPendingFriendRequestQueryHandler));
            services.AddMediatR(typeof(GetUserFriendsListQueryHandler));
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
            //services.Configure<ApplicationSettings>(applicationSettings);
            return services;
        }

        public static IServiceCollection AddJWTSettings(this IServiceCollection services, IConfigurationSection jwtSettings)
        {
            services.Configure<JWTSettings>(jwtSettings);
            services.AddSingleton(svc => svc.GetService<IOptions<JWTSettings>>().Value);
            var key = Encoding.UTF8.GetBytes(jwtSettings["JWT_Secret"].ToString());

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
