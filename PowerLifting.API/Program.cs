using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerLifting.Data.Entities;
using PowerLifting.Data.SeedData;
using Sentry;

namespace PowerLifting.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //var host = new WebHostBuilder()
            //   .UseKestrel()
            //   .UseUrls("http://*:80")
            //  .UseContentRoot(Directory.GetCurrentDirectory())
            //   .UseIISIntegration()
            //   .UseStartup<Startup>()
            //   .Build();
            using (SentrySdk.Init("https://003ac788373e4e79b2f899569561bc5a@o422243.ingest.sentry.io/5346139"))
            {
                // App code

                using (var scope = host.Services.CreateScope())
                {


                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<PowerLiftingContext>();
                        DbInitializer.Initialize(context);
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
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                 
                });
    }
}
