using ProjecIntegration.Api.Models;
using System.Linq.Expressions;

namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T entity);
        void Update(int updtId, T entity);
        void Delete(int entityid);
    }
}
