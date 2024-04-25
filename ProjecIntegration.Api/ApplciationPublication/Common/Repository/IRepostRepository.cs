using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Common.Repository
{
    public interface IRepostRepository 
    {
        Task<IEnumerable<RePost>> GetAll(params Expression<Func<RePost, object>>[] includeProperties);
        Task<RePost> GetById(string id, params Expression<Func<RePost, object>>[] includeProperties);
        Task<IEnumerable<RePost>> GetAll();
        Task<RePost> GetById(string id);
        void Insert(RePost entity);
        void Update(string entityId, RePost entity);
        void Delete(string entityId);
    }
}
