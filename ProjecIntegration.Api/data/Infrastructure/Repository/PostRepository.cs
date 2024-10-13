using ApplicationPublication.Common.Repository;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using Domain.Entity.publicationEntity;

namespace InfraPublication.Repository
{
    public class PostRepository : Repository<Post> ,IPostRepository
    {

        private readonly ApplicationDbContext dbContext;
        public PostRepository(ApplicationDbContext database): base(database) 
        {
            dbContext = database;
        }

        public Task<IEnumerable<Post>> GetAllFromPublication(int publicationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllFromUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(int postId, string content)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(int entityId, Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
