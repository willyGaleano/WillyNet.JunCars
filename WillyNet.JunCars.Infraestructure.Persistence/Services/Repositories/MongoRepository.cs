using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Application.Interfaces.Repository;
using WillyNet.JunCars.Core.Domain.Common;

namespace WillyNet.JunCars.Infraestructure.Persistence.Services.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> collection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            collection = database.GetCollection<T>(collectionName);
        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await collection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, entity.Id);
            await collection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(string id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);
            await collection.DeleteOneAsync(filter);
        }
    }
}
