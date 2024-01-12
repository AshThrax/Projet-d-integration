using ProjecIntegration.Api.Models.BaseEntity;

namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T entity);
        void Update(int updtId,T entity);
        void Delete(T entity);
    }
}
