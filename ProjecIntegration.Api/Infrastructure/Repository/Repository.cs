using ApplicationAnnonce.Common.Repository;
using Domain.Entity;
using InfrastructureAnnonce.Persistence;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace InfrastructureAnnonce.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : BaseMongoEntity
    {
        private readonly IMongoCollection<T> _mongoCollection;
        private readonly NotificationMongoContext _notificationMongoContext;
        public MongoRepository(NotificationMongoContext database)
        {
            _notificationMongoContext = database;
            _mongoCollection = database.Dbset<T>();
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

        public async Task Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                await _mongoCollection.InsertOneAsync(entity);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Update(string entityId, T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                await _mongoCollection.ReplaceOneAsync(x => x.Id == entityId, entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(string entityId)
        {
            try
            {
                await _mongoCollection.DeleteOneAsync(x => x.Id == entityId);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
