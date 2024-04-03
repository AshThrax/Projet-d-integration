using WebApi.Application.DTO;

namespace WebApi.BusinessService.Complexe
{
    public interface IBusinessComplexe
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ComplexeDto>> GetAllComplexe();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ComplexeDto> GetComplexe(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="complexeDto"></param>
        /// <returns></returns>
        void CreateAsync(ComplexeDto complexeDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="complexeDto"></param>
        /// <returns></returns>
        Task UpdateAsync(int id, UpdateComplexeDto complexeDto);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task Delete(int id);

    }
}
