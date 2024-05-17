using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.Repository
{
    public interface IRepository<T> where T : BaseMongoEntity
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(string id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(string id);
        void Insert(T entity);
        void Update(string entityId, T entity);
        void Delete(string entityId);
    }
}