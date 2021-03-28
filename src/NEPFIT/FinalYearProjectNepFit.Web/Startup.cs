using FinalYearProjectNepFit.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NepFit.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NepFit.BL;
using NepFit.BL.Interface;
using NepFit.Repository;
using NepFit.Repository.Mapper;
using NepFit.Repository.Repository;
using NepFit.Repository.Repository.Interface;

namespace FinalYearProjectNepFit.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                // options.UseSqlite(
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            
      
                
      
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["App:GoogleClientId"];
                    options.ClientSecret = Configuration["App:GoogleClientSecret"];
                });
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.AddTransient<IEmailSender, EmailSender>(i =>
               new EmailSender(
                   Configuration["EmailSender:Host"],
                   Configuration.GetValue<int>("EmailSender:Port"),
                   Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   Configuration["EmailSender:UserName"],
                   Configuration["EmailSender:Password"]
               )
           );
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<ISqlServerConnectionProvider>(provider =>
                new SqlServerConnectionProvider(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IBodyMetricsRepository, BodyMetricsRepository>();
            services.AddScoped<IBodyMetricsService, BodyMetricsService>();

            services.AddScoped<IProgressTrackerRepository, ProgressTrackerRepository>();
            services.AddScoped<IProgressTrackerService, ProgressTrackerService>();

            services.AddScoped<IExerciseTypeService, ExerciseTypeService>();
            services.AddScoped<IExerciseTypeRepository, ExerciseTypeRepository>();

            services.AddScoped<IExercisePackageRepository, ExercisePackageRepository>();
            services.AddScoped<IExercisePackageService, ExercisePackageService>();

            services.AddScoped<IExerciseRoutineRepository, ExerciseRoutineRepository>();
            services.AddScoped<IExerciseRoutineService, ExerciseRoutineService>();

            services.AddScoped<IExercisePackageRoutineRepository, ExercisePackageRoutineRepository>();
            services.AddScoped<IExercisePackageRoutineService, ExercisePackageRoutineService>();

            services.AddScoped<INutritionTypeRepository, NutritionTypeRepository>();
            services.AddScoped<INutritionTypeService, NutritionTypeService>();

            services.AddScoped<INutritionPackageService, NutritionPackageService>();
            services.AddScoped<INutritionPackageRepository, NutritionPackageRepository>();

            services.AddScoped<INutritionRoutineService, NutritionRoutineService>();
            services.AddScoped<INutritionRoutineRepository, NutritionRoutineRepository>();

            services.AddScoped<INutritionPackageRoutineService, NutritionPackageRoutineService>();
            services.AddScoped<INutritionPackageRoutineRepository, NutritionPackageRoutineRepository>();


            services.AddScoped<IExerciseNutritionPackageService, ExerciseNutritionPackageService>();
            services.AddScoped<IExerciseNutritionPackageRepository, ExerciseNutritionPackageRepository>();


            services.AddScoped<INepFitUserService, NepFitUserService>();
            services.AddScoped<INepFitUserRepository, NepFitUserRepository>();



          



            services.AddSwaggerGen();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
