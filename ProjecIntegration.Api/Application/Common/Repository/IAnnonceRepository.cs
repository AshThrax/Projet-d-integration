using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repository
{
    public interface IAnnonceRepository
    {
        Task<IEnumerable<Annonce>> GetAll(params Expression<Func<Annonce, object>>[] includeProperties);
        Task<Annonce> GetById(string id, params Expression<Func<Annonce, object>>[] includeProperties);
        Task<IEnumerable<Annonce>> GetAll();
        Task<Annonce> GetById(string id);
        void Insert(Annonce entity);
        void Update(string entityId,Annonce entity);
        void Delete(string entityId);
    }
}
