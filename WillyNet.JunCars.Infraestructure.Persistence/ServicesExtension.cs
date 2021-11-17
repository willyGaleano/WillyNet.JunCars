using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Application.Interfaces.Repository;
using WillyNet.JunCars.Core.Domain.Common;
using WillyNet.JunCars.Core.Domain.Settings;
using WillyNet.JunCars.Infraestructure.Persistence.Services.Repositories;

namespace WillyNet.JunCars.Infraestructure.Persistence
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {        
            services.AddSingleton(a =>
            {
                var configuration = a.GetService<IConfiguration>();                
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
                return mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
            });

            return services;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
        {
            services.AddSingleton<IRepository<T>>(a =>
            {
                var database = a.GetService<IMongoDatabase>();
                return new MongoRepository<T>(database, collectionName);
            });
            return services;
        }
    }
}
