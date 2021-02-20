using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Services.Account;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.App.Services.LiftingStats;
using PowerBuddy.App.Services.Templates;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.App.Services.Workouts;

namespace PowerBuddy.App.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServiceClasses(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILiftingStatService, LiftingStatService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IWeightInsertConvertorService, WeightInsertConvertorService>();
            services.AddScoped<IWeightOutgoingConvertorService, WeightOutgoingConvertorService>();

            return services;
        }
    }
}
