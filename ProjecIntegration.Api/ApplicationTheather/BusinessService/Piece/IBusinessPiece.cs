using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService.Piece
{
    public interface IBusinessPiece
    {
        /// <summary>
        /// creer une piece de theatre dans la database
        /// </summary>
        /// <param name="Entity">entité pièce de theatre a ajoutée</param>
        /// <returns></returns>
        Task<ServiceResponse<PieceDto>> Create(AddPieceDto Entity);
        /// <summary>
        /// suprrimer une piece de theatre de la database 
        /// </summary>
        /// <param name="idPIece"></param>
        /// <returns></returns>
        Task<ServiceResponse<PieceDto>> Delete(int idPIece);
        /// <summary>
        /// mets a jour une pice d theatres
        /// </summary>
        /// <param name="idPiece">id de la pîece qu'on désire </param>
        /// <param name="Entity">l'entité a metre a jour</param>
        /// <returns></returns>
        Task<ServiceResponse<PieceDto>> Update(int idPiece, UpdatePieceDto Entity);
        /// <summary>
        /// récupère une liste de pièce de theatre
        /// </summary>
        /// <returns>liste de piece de theatre</returns>
        Task<ServiceResponse<IEnumerable<PieceDto>>> GetAll();
        /// <summary>
        /// récupére une piece de theatre avec ses info
        /// </summary>
        /// <param name="idPIece"></param>
        /// <returns> une piece de theatre</returns>
        Task<ServiceResponse<PieceDto>> Get(int idPIece);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPiece"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<PieceDto>>> GetPiecefromCatalogue(int idPiece);
        /// <summary>
        /// récupération des piece de théatre par theme
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<PieceDto>>> GetPieceByTheme(int themeId);
    }
}
