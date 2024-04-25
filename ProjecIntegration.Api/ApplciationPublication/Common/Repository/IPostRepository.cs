using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Common.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll(params Expression<Func<Post, object>>[] includeProperties);
        Task<Post> GetById(string id, params Expression<Func<Post, object>>[] includeProperties);
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(string id);
        void Insert(Post entity);
        void Update(string entityId, Post entity);
        void Delete(string entityId);
        Task Update(string postId,string content);
    }
}
