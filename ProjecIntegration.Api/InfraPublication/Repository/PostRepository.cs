using ApplicationPublication.Common.Repository;
using Domain.Entity.publicationEntity;
using InfraPublication.BusinessLayer;
using InfraPublication.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Repository
{
    public class PostRepository : MongoRepository<Post> ,IPostRepository
    {
       
        private readonly IMongoCollection<Post> _mongoCollection;
        public PostRepository(PublicationMongoContext database): base(database) 
        {
            _mongoCollection = database.DbSet<Post>();
        }

       

        public async Task<IEnumerable<Post>> GetAllFromPublication(string publicationId)
        {
            FilterDefinitionBuilder<Post> builder = Builders<Post>.Filter;
            FilterDefinition<Post> filter = builder.Where(x=>x.PublicationId==publicationId);

            return await _mongoCollection.Find(filter)
                                    .ToListAsync();
        }

        public Task Insert(string publicationId, Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string postId, string content)
        {
            
            var filter = Builders<Post>.Filter.Eq(x =>x.Id, postId);
            var update=Builders<Post>.Update.Set(x =>x.Content,content)
                                            .Set(x => x.UpdatedDate, DateTime.Now);
            await _mongoCollection.UpdateOneAsync(filter,update);
        }

        public  async Task UpdateEntity(string entityId, Post entity)
        {
            var filter = Builders<Post>.Filter.Eq(x => x.Id,entityId);
            var update = Builders<Post>.Update.Set(x => x, entity);

            await _mongoCollection.ReplaceOneAsync(x=> x.Id==entityId,entity);
        }
    }
}
