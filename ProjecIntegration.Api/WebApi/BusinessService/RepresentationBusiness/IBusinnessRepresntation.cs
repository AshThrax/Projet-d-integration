using data.Interfaces.IRepository;

namespace WebApi.BusinessService
{
    public interface IBusinessRepresentation
    {
        /// <summary>
        /// récupere toutes les rpesentation
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RepresentationDto>> getAll();
        /// <summary>
        /// récupère toutes les represnetaion en fcontion d'un complexe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<RepresentationDto>> getAllFromComplexe(int id);
        /// <summary>
        /// recupère toutes les represnetation liée a une pièece de theatre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<RepresentationDto>> getAllFromPiece(int id);
        /// <summary>
        /// récupère une representation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RepresentationDto> getById(int id);
        /// <summary>
        /// Crée une representation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Create (RepresentationDto dto);
        /// <summary>
        /// mest a jour une represnetaion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Update (int id ,RepresentationDto dto);
        /// <summary>
        /// supprimùe un represnetation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
   
}
