using AutoMapper;
using HotChocolate.AspNetCore;
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
using PowerLifting.Data.Entities.Account;
using PowerLifting.API.Extensions;
using PowerLifting.API.GraphQL;
using PowerLifting.Data.Entities;
using PowerLifting.Service.Account;
using PowerLifting.Service.LiftingStats;

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
            services.AddSystemMediatrHandlers();
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

            //services.AddScoped<IProgramLogService, ProgramLogService>();

            //Inject app settings
            services.AddJWTSettings(Configuration.GetSection("JWTSettings"));
            services.AddSentry(Configuration.GetSection("Sentry"));
            //services.AddPowerLiftingContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<PowerLiftingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddCorsPolicy(Configuration.GetSection("CorsPolicy"));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder.WithOrigins(Configuration["CorsPolicy:Client_URL"].ToString())
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //services.AddDbContext<PowerliftingContext>(options =>
            //  options.UseSqlite("DataSource = app.db"));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PowerLiftingContext>();

            services.AddControllers();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILiftingStatService, LiftingStatService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new SystemAutoMapperProfile());
                 mc.AddProfile(new LiftingStatMappingProfile());
                 mc.AddProfile(new ProgramLogMappingProfile());
                 mc.AddProfile(new TemplateProgramMappingProfile());
                 mc.AddProfile(new AccountMappingProfile());
             });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddGraphQLServices();

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
            app.UseGraphQL("/graphql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
