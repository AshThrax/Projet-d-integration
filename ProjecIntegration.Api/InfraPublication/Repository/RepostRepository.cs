using ApplicationPublication.Common.Repository;
using Domain.Entity.publicationEntity;
using InfraPublication.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Repository
{
    public class RepostRepository : MongoRepository<Repost>, IRepostRepository
    {
        
        private readonly IMongoCollection<Repost> _reposts;
        public RepostRepository(PublicationMongoContext database) :base(database) 
        {
            _reposts = database.DbSet<Repost>();
        }

        public Task<IEnumerable<Repost>> GetAllFromPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public Task Update(string entityId, string content)
        {
            throw new NotImplementedException();
        }
    }
}
