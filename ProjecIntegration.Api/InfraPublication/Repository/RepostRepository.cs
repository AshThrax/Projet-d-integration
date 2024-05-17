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
    public class RepostRepository : MongoRepository<RePost>, IRepostRepository
    {
        
        private readonly IMongoCollection<RePost> _reposts;
        public RepostRepository(PublicationMongoContext database) :base(database) 
        {
            _reposts = database.DbSet<RePost>();
        }

        public Task<IEnumerable<RePost>> GetAllFromPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public Task Update(string entityId, string content)
        {
            throw new NotImplementedException();
        }
    }
}
