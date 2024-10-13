using Domain.Entity;
using System.Linq.Expressions;

namespace dataInfraTheather.Infrastructure.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Delete(int entityid);
        Task<bool> DoYouExist(Expression<Func<T, bool>> includeProperties);
        Task<bool> DoYouExist(int id);
        Task<T> Get(Expression<Func<T, bool>> includeProperties);
        Task<T> Get(Expression<Func<T, bool>> findProperties, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllCustomWithInclude(Expression<Func<T, bool>> findProperties, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetByListIds(List<int> ListIds);
        Task<T> Insert(T entity);
        Task Update(int updtId, T entity);
    }
}