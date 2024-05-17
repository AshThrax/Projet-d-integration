using ApplicationPublication.Common.Repository;
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

        public MongoRepository(PublicationMongoContext database )
        {
            _mongoCollection =database.DbSet<T>();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id, params Expression<Func<T, object>>[] includeProperties)
        {
           
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _mongoCollection.FindSync(x => x.Id == id).FirstOrDefaultAsync();
            
           
          
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T?> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            else 
            { 
                return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            }
        }

        public void Insert(T entity)
        {
            try 
            {
               if (entity ==null)
               {
                    throw new ArgumentNullException(nameof(entity));
               }
                _mongoCollection.InsertOne(entity);
            }
            catch(ArgumentNullException)
            { 
                // dans le cas ou l'entité passé en argument n'est pas 
                //bon
            }
            catch (Exception)
            {

            }
           
        }

        public void Update(string entityId, T entity)
        {
            try 
            {
                if (string.IsNullOrEmpty(entityId))
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                _mongoCollection.ReplaceOne(x => x.Id == entityId, entity);  
            }
            catch (Exception )
            {

            }
        }

        public void Delete(string entityId)
        {
            try
            {
                if (string.IsNullOrEmpty(entityId))
                {
                    _mongoCollection.DeleteOne(x => x.Id == entityId);
                }
            }
            catch(Exception )
            {

            }
        }
    }
}
