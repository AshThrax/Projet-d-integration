
using Application.Common.Repository;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _mongoCollection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _mongoCollection.FindSync(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _mongoCollection.InsertOne(entity);
        }

        public void Update(int entityId, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _mongoCollection.ReplaceOne(x => x.Id == entityId, entity);
        }

        public void Delete(int entityId)
        {
            _mongoCollection.DeleteOne(x => x.Id == entityId);
        }
    }
}
