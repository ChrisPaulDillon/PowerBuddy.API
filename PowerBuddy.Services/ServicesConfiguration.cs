using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Authentication;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs;
using PowerBuddy.Services.System;
using PowerBuddy.Services.Templates;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServiceClasses(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILiftingStatService, LiftingStatService>();
            services.AddScoped<IProgramLogService, ProgramLogService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IWorkoutService, WorkoutService>();

            return services;
        }
    }
}
