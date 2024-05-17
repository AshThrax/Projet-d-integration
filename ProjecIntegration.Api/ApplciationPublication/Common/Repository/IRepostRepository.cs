using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.Repository
{
    public interface IRepostRepository : IRepository<RePost>
    {
        Task<IEnumerable<RePost>> GetAllFromPostId(int postId);
        Task<RePost?> GetById(string id);
        Task Update(string entityId, string content);
    }
}
