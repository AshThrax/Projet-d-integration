using Domain.Entity;
using System.Linq.Expressions;

namespace ApplicationAnnonce.Common.Repository
{

    public interface IRepository<T> where T : BaseMongoEntity
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(string id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> DoYouExist(string id);
        Task Insert(T entity);
        Task Update(string entityId, T entity);
        Task Delete(string entityId);
    }
}

