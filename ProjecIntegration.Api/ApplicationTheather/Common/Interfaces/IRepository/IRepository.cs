using Domain.Entity;
using System.Linq.Expressions;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T entity);
        void Update(int updtId, T entity);
        Task Delete(int entityid);
    }
}
