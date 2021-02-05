using System;
using System.IO;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Context.SeedData;
using Serilog;

namespace PowerBuddy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<Program>()
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
                    var logger = services.GetRequiredService<ILogger<Program>>();
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
	                webBuilder.UseMetricsWebTracking();
	                webBuilder.UseMetrics(opt =>
	                {
		                opt.EndpointOptions = endpointOptions =>
                        {
                            endpointOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                            endpointOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
			                endpointOptions.EnvironmentInfoEndpointEnabled = false;
		                };
	                });
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
