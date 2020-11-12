using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PowerLifting.API.AuthorizationHandlers;
using PowerLifting.API.Middleware;
using PowerLifting.Data.AutoMapper;
using PowerLifting.API.Extensions;
using PowerLifting.Data;
using PowerLifting.Data.Entities;

namespace PowerLifting.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Mediatr Services
            services.AddProgramLogDayMediatrHandlers();
            services.AddProgramLogMediatrHandlers();
            services.AddProgramLogWeekMediatrHandlers();
            services.AddProgramLogExerciseMediatrHandlers();
            services.AddProgramLogRepSchemesMediatrHandlers();
            services.AddExerciseMediatrHandlers();
            services.AddExerciseMuscleGroupHandlers();
            services.AddExerciseTypeMediatrHandlers();
            services.AddQuoteMediatrHandlers();
            services.AddLiftingStatsMediatrHandlers();
            services.AddNotificationsMediatrHandlers();
            services.AddTemplateProgramMediatrHandlers();
            services.AddUserMediatrHandlers();
            services.AddFriendsListsMediatrHandlers();

            services.AddFactories();

            //Inject app settings
            services.AddJWTSettings(Configuration.GetSection("JWTSettings"));
            services.AddSentry(Configuration.GetSection("Sentry"));
            services.AddDbContext<PowerLiftingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(Configuration["CorsPolicy:Client_URL"])
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .WithMethods("GET", "PUT", "POST", "DELETE");
                    });
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PowerLiftingContext>();

            services.AddControllers();

            services.AddServiceClasses();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new SystemAutoMapperProfile());
                 mc.AddProfile(new LiftingStatMappingProfile());
                 mc.AddProfile(new ProgramLogMappingProfile());
                 mc.AddProfile(new TemplateProgramMappingProfile());
                 mc.AddProfile(new AccountMappingProfile());
                 mc.AddProfile(new FriendsListMappingProfile());
             });

            var mapper = mappingConfig.CreateMapper();
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

            services.AddTransient<IAuthorizationHandler, IsModeratorAuthorizationHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsModerator",
                    policy => policy.Requirements.Add(new IsModeratorValidationRequirement()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PowerBuddy V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
