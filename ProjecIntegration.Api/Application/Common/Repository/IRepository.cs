
using Domain.Entity;
using System.Linq.Expressions;

namespace Application.Common.Repository
{
    public interface IRepository<T> where T : class
    {
        public interface IRepository<T> where T : BaseEntity
        {
            Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
            Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
            Task<IEnumerable<T>> GetAll();
            Task<T> GetById(int id);
            void Insert(T entity);
            void Update(int entityId, T entity);
            void Delete(int entityId);
        }
    }
}
