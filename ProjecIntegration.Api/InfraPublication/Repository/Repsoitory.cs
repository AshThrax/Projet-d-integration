using ApplciationPublication.Common.Repository;
using Domain.Entity;
using InfraPublication.Persistence;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;


namespace InfraPublication.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : BaseMongoEntity
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public MongoRepository(IMongoDatabase database)
        {
            _mongoCollection = database.GetCollection<T>(nameof(T));
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _mongoCollection.FindSync(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id)
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

        public void Update(string entityId, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _mongoCollection.ReplaceOne(x => x.Id == entityId, entity);
        }

        public void Delete(string entityId)
        {
            _mongoCollection.DeleteOne(x => x.Id == entityId);
        }
    }
}
