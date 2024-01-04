using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.Models.BaseEntity;

namespace ProjecIntegration.Api.Application.Common.Interfaces.IService
{
    public interface IGeneriqueService<T ,U> where T : BaseEntity where U : BaseDto
    {
        Task<U> Add(U entity);
        void Delete(U entity);
        Task<U> Update(U entity);
        Task<U> GetById(int id);
        Task<IEnumerable<U>> GetAll();
    }
}
