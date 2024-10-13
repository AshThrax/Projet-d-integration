using ApplicationTheater.Common;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.Repository
{
    public interface IPostRepository:IRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllFromUserId(string userId);
        Task<IEnumerable<Post>> GetAllFromPublication(int publicationId);
        Task UpdateEntity(int entityId, Post entity);
        Task Update(int postId, string content);
    }
}
