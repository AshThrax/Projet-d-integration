using ApplicationTheather.DTO;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService.Representation
{
    public interface IBusinessRepresentation
    {
        /// <summary>
        /// récupere toutes les rpesentation
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAll();
        /// <summary>
        /// récupère toutes les represnetaion en fcontion d'un complexe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAllFromComplexe(int ComplexeId);
        /// <summary>
        /// recupère toutes les represnetation liée a une pièce de theatre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAllFromPiece(int pieceId);
        /// <summary>
        /// récupèrer les representation par salle
        /// </summary>
        /// <param name="salleId"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAllFromSalle(int salleId);
        /// <summary>
        /// récupère une representation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<RepresentationDto>> GetById(int id);
        /// <summary>
        /// Crée une representation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ServiceResponse<RepresentationDto>> Create(AddRepresentationDto dto);
        /// <summary>
        /// mest a jour une represnetaion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>

        ///
        Task AddCommandtoRepresentation(AddCommandDto addCommandDto);
        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ServiceResponse<RepresentationDto>> Update(int id, UpdateRepresentationDto dto);
        /// <summary>
        /// supprimùe un represnetation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<RepresentationDto>> Delete(int id);
    }

}
