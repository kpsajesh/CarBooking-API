//using CarBookingData;
using AspNetCoreRateLimit;
using CarBookingData.Configurations;
using CarBookingData.DataModels;
using CarBookingRepository.Contracts;
using CarBookingRepository.Repositories;
using CarBookingRepository.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarBooking_API
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
            services.AddDbContext<CarBookingDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMemoryCache();
            services.ConfigurerateLimiting();
            services.AddHttpContextAccessor();

            //services.AddResponseCaching();
            services.ConfigureHttpCacheheaders();

            services.AddAuthentication();
            services.ConfigureIdentity();            

            services.ConfigureJWT(Configuration);

            services.AddCors(o => { // For Defining the access policy
                o.AddPolicy("AllowAll", builder =>
                            builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(MapperInitialiser));

            //Not needed to register the IGENRIIC class as we have made the UnitofWork with injecting the DB Context
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUnitofWork, UnitofWork>();
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddSwaggerGen(c => // Swagger automatically creates the API documentation for the developers who are using the API endpoints
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car Booking API", Version = "v1" });
            });

            /* this was the existing, change implementing cache at high level
             services.AddControllers().AddNewtonsoftJson(op => 
                        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);*/
            //Caching is implemented as below
            services.AddControllers(config => {
                config.CacheProfiles.Add("CacheDuration", new CacheProfile
                {
                    Duration = 120
                });
            }).AddNewtonsoftJson(op =>
                        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.ConfigureVersioning();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarBooking_API v1"));

            app.ConfigureExceptionHandler();
            

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");// Applying the AllowAll rule defined above.

            app.UseResponseCaching();
            app.UseHttpCacheHeaders();

            //app.UseIpRateLimiting(); Throttling is not working. Enabling this leads to HTTP Error 500.30 - ASP.NET Core app failed to start

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseApiVersioning();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
