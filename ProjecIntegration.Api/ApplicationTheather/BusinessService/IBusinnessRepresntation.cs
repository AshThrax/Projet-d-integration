using ApplicationTheather.DTO;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessRepresentation
    {
        /// <summary>
        /// récupere toutes les rpesentation
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RepresentationDto>> GetAll();
        /// <summary>
        /// récupère toutes les represnetaion en fcontion d'un complexe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<RepresentationDto>> GetAllFromComplexe(int id);
        /// <summary>
        /// recupère toutes les represnetation liée a une pièece de theatre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<RepresentationDto>> GetAllFromPiece(int id);
        /// <summary>
        /// récupère une representation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RepresentationDto> GetById(int id);
        /// <summary>
        /// Crée une representation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Create(AddRepresentationDto dto);
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
        Task Update(int id, UpdateRepresentationDto dto);
        /// <summary>
        /// supprimùe un represnetation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }

}
