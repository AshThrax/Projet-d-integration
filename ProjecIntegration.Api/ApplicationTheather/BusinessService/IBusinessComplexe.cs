using ApplicationTheather.DTO;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessComplexe
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<ComplexeDto>>> GetAllComplexe();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<ComplexeDto>> GetComplexe(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="complexeDto"></param>
        /// <returns></returns>
        Task<ServiceResponse<ComplexeDto>> CreateAsync(AddComplexeDto complexeDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="complexeDto"></param>
        /// <returns></returns>
        Task<ServiceResponse<ComplexeDto>> UpdateAsync(int id, UpdateComplexeDto complexeDto);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<ComplexeDto>> Delete(int id);

    }
}
