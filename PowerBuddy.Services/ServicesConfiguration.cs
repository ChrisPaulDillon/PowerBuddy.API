using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Authentication;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.System;
using PowerBuddy.Services.Templates;
using PowerBuddy.Services.Weights;
using PowerBuddy.Services.Workouts;
using PowerBuddy.Services.Workouts.Factories;
using PowerBuddy.Services.Workouts.Strategies;

namespace PowerBuddy.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServiceClasses(this IServiceCollection services)
        {
            services.AddScoped<ICalculateWeightFactory, CalculateWeightFactory>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightIncremental>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightPercentage>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILiftingStatService, LiftingStatService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IWeightInsertConvertorService, WeightInsertConvertorService>();
            services.AddScoped<IWeightOutgoingConvertorService, WeightOutgoingConvertorService>();

            return services;
        }
    }
}
