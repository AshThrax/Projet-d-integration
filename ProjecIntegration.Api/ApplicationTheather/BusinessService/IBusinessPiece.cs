using WebApi.Application.DTO;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessPiece
    {
        /// <summary>
        /// creer une piece de theatre dans la database
        /// </summary>
        /// <param name="Entity">entité pièce de theatre a ajoutée</param>
        /// <returns></returns>
        Task Create(AddPieceDto Entity);
        /// <summary>
        /// suprrimer une piece de theatre de la database 
        /// </summary>
        /// <param name="idPIece"></param>
        /// <returns></returns>
        Task Delete(int idPIece);
        /// <summary>
        /// mets a jour une pice d theatres
        /// </summary>
        /// <param name="idPiece">id de la pîece qu'on désire </param>
        /// <param name="Entity">l'entité a metre a jour</param>
        /// <returns></returns>
        Task Update(int idPiece, UpdatePieceDto Entity);
        /// <summary>
        /// récupère une liste de pièce de theatre
        /// </summary>
        /// <returns>liste de piece de theatre</returns>
        Task<IEnumerable<PieceDto>> GetAll();
        /// <summary>
        /// récupére une piece de theatre avec ses info
        /// </summary>
        /// <param name="idPIece"></param>
        /// <returns> une piece de theatre</returns>
        Task<PieceDto> Get(int idPIece);
    }
}
