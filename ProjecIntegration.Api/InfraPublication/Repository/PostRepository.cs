using ApplciationPublication.Common.Repository;
using Domain.Entity.publicationEntity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Repository
{
    public class PostRepository : MongoRepository<Post>, IPostRepository
    {
       
        private readonly IMongoCollection<Post> _mongoCollection;
        public PostRepository(IMongoDatabase database) : base(database)
        {
            _mongoCollection = database.GetCollection<Post>(nameof(Post));
        }

        public async Task Update(string postId, string content)
        {
            
            var filter = Builders<Post>.Filter.Eq(x =>x.Id, postId);
            var update=Builders<Post>.Update.Set(x =>x.Content,content);

            await _mongoCollection.UpdateOneAsync(filter,update);
        }
    }
}
