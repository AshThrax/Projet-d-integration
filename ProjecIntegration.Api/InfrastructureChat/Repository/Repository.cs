using ApplicationChat.Common.Interface;
using Domain.Entity;
using InfrastructureChat.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureChat.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : BaseMongoEntity
    {
        private readonly IMongoCollection<T> _mongoCollection;
        private readonly ChatMongoContext _ChatContext;
        public MongoRepository(ChatMongoContext database)
        {
            _ChatContext = database;
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

        public async Task<bool> DoYouExist(string id)
        {
            try
            {
                int count = (int)await _mongoCollection.Find(x => x.Id == id).CountDocumentsAsync();

                return count > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
