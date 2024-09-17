using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByListIds(List<int> ListIds);
        Task<T> GetById(int id);
        Task<bool> DoYouExist(int id);
        Task<T> Insert(T entity);
        Task Update(int updtId, T entity);
        Task Delete(int entityid);
    }
}
