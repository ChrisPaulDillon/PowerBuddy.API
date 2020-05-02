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
using PowerLifting.Service.Users.Model;
using Microsoft.AspNetCore.Http;
using PowerLifting.Persistence;
using PowerLifting.Repository;
using PowerLifting.Service;
using PowerLifting.Service.Exercises.AutoMapper;
using PowerLifting.Service.LiftingStats.AutoMapper;
using PowerLifting.Service.ProgramLogs.AutoMapper;
using PowerLifting.Service.TemplatePrograms.AutoMapper;
using PowerLifting.Service.Users.AutoMapper;
using PowerLifting.Service.UserSettings.AutoMapper;

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


            services.AddDbContext<PowerliftingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<PowerliftingContext>(options =>
             //  options.UseSqlite("DataSource = app.db"));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PowerliftingContext>();


            //services.AddIdentity<User, IdentityRole>()
            //   .AddRoles<IdentityRole>()
            //   .AddEntityFrameworkStores<PowerliftingContext>()
            //  .AddDefaultUI()
            //  .AddDefaultTokenProviders();

    
            services.AddControllers();

            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerManager, LoggerManager>();

            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new ExerciseServiceMappingProfile());
                 mc.AddProfile(new LiftingStatServiceMappingProfile());
                 mc.AddProfile(new ProgramLogMappingProfile());
                 mc.AddProfile(new TemplateProgramMappingProfile());
                 mc.AddProfile(new UserMappingProfile());
                 mc.AddProfile(new UserSettingMappingProfile());
             });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

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
