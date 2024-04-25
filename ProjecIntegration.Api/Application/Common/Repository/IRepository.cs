
using Domain.Entity;
using System.Linq.Expressions;

namespace Application.Common.Repository
{
  
        public interface IRepository 
    {
            Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
            Task<T> GetById(string id, params Expression<Func<T, object>>[] includeProperties);
            Task<IEnumerable<T>> GetAll();
            Task<T> GetById(string id);
            void Insert(T entity);
            void Update(string entityId, T entity);
            void Delete(string entityId);
        }
    }

