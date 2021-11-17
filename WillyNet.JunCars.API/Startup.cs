using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillyNet.JunCars.API.Extensions;
using WillyNet.JunCars.Core.Application;
using WillyNet.JunCars.Core.Application.Interfaces;
using WillyNet.JunCars.Core.Application.Interfaces.Repository;
using WillyNet.JunCars.Core.Domain.Entities;
using WillyNet.JunCars.Infraestructure.Persistence;
using WillyNet.JunCars.Infraestructure.Persistence.Services.Repositories;

namespace WillyNet.JunCars.API
{
    public class Startup
    {
        readonly string myPolicy = "policyApiJunCars";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddApplicationLayer();
            services.AddMongo();
            services.AddMongoRepository<User>("User");
            services.AddMongoRepository<Car>("Car");
            services.AddMongoRepository<Booking>("Booking");

            services.AddApiVersioningExtension();
            services.AddSwaggerExtension();
            services.AddControllers();            
            services.AddCors(options => options.AddPolicy(myPolicy,
                              builder => builder.WithOrigins(Configuration["Cors:OriginCors"])
                                               .AllowAnyHeader()
                                               .AllowAnyMethod()
                                               .AllowCredentials()
                             ));          
        }        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseErrorHandlingMiddleware();
            app.UseRouting();
            app.UseSwaggerExtension();
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
