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
       
        Task<IEnumerable<Post>> GetAllFromPublication(string publicationId);
        Task Insert(string publicationId, Post entity);
        void Update(string entityId, Post entity);
        Task Update(string postId, string content);
    }
}
