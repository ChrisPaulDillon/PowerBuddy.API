using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Context.SeedData;
using Sentry;
using Serilog;

namespace PowerBuddy.API
{
    public class Workout
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<Workout>()
                .Build();

            var sentryDSN = config.GetSection("Sentry_DSN");

            var host = CreateHostBuilder(args, sentryDSN).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<PowerLiftingContext>();
                    DbInitializer.InitializeAsync(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Workout>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
            throw new Exception();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationSection sentry) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSerilog((ctx, config) =>
                    {
                        config.ReadFrom.Configuration(ctx.Configuration, "Serilog");
                        config.WriteTo.Console();
                        config.WriteTo.Sentry(c =>
                        {
                            // SDK is initialized through UseSentry method below
                            c.InitializeSdk = false;
                        });
                    });
                    webBuilder.UseSentry(sentry.Value);
                    webBuilder.UseStartup<Startup>();

                });
    }
}
