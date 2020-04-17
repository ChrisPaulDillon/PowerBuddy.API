using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;
using PowerLifting.LoggerService;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users.Model;
using Microsoft.AspNetCore.Http;
using PowerLifting.Persistence;
using PowerLifting.Repository;

namespace PowerLifting.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
      

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //services.AddDbContext<PowerliftingContext>(options =>
             //   options.UseSqlite(
             //       Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PowerliftingContext>();

             services.AddDbContext<PowerliftingContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<User, IdentityRole>()
            //   .AddRoles<IdentityRole>()
            //   .AddEntityFrameworkStores<PowerliftingContext>()
            //  .AddDefaultUI()
            //  .AddDefaultTokenProviders();

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped<IExerciseService, ExerciseService>();


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PowerBuddy API", Version = "v1" });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //        builder =>
            //        {
            //            builder.WithOrigins("https://localhost:44329/",
            //                "https://localhost:5001/");
            //        });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler(logger);
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
