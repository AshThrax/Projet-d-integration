using Domain.ServiceResponse;
using ApplicationTheather.DTO;
namespace ApplicationTheather.BusinessService.Salle
{
    public interface IBusinessSiege
    {
        /// <summary>
        /// /
        /// </summary>
        /// <param name="salleId"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<SiegeDto>>> GetSiegeFromSalleId(int salleId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siegeId"></param>
        /// <returns></returns>
        Task<ServiceResponse<SiegeDto>> GetSiegeById(int siegeId);
        /// <summary>
        /// /
        /// </summary>
        /// <param name="siege"></param>
        /// <returns></returns>
        Task<ServiceResponse<SiegeDto>> CreateSiegeForSalle(AddSiegeDto siege);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SiegeId"></param>
        /// <returns></returns>
        Task<ServiceResponse<SiegeDto>> DeleteSiegeById(int SiegeId);
        /// <summary>
        /// mets a jour les information lier a un siege 
        /// </summary>
        /// <param name="SiegeId"></param>
        /// <param name="siege"></param>
        /// <returns></returns>
        Task<ServiceResponse<SiegeDto>> UpdateSiegeById(int SiegeId, UpdateSiegeDto siege);
        /// <summary>
        /// récupère les Sieges
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<SiegeDto>>> GetSiegeFromCommand(int command);

        Task<ServiceResponse<IEnumerable<SiegeDto>>> GetAvailbleByrepresentationId(int representationId, int salleId);
    }
}
