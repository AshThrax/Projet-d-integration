using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.Repository
{
    public interface IRepostRepository : IRepository<Repost>
    {
        Task<IEnumerable<Repost>> GetAllFromPostId(int postId);
        Task Update(string entityId, string content);
    }
}
