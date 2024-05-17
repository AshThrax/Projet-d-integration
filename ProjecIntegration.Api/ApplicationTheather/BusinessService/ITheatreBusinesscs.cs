using ApplicationTheather.DTO;

namespace ApplicationTheather.BusinessService
{
    public interface ITheatreBusiness
    {
      
        /// <summary>
        /// Créer une representation pour une piéce donnée
        /// </summary>
        /// <param name="IdPiece">l'identifiant de la piece de theatre</param>
        /// <param name="idSalle">l'identifiant de la salle</param>
        /// <returns></returns>
        Task CreateRepresentationForPiece(int IdPiece, int idSalle, AddRepresentationDto represnetaion);
        /// <summary>
        /// supprimer une representation liée a une piece de theatre 
        /// </summary>
        /// <param name="idRepresentation"> l'identifiant de la represnetation</param>
        /// <param name="IdPiece">l'identifiant de la piece de theatre</param>
        /// <returns></returns>
        Task DeleteRepresentationForPiece(int idRepresentation, int IdPiece);
        /// <summary>
        /// récupère les representation d'une salle 
        /// </summary>
        /// <param name="IdPiece">identifiant de la piece</param>
        /// <returns>une liste de representation</returns>
        Task<IEnumerable<RepresentationDto>> GetRepresentationFromPiece(int IdPiece);
        /// <summary>
        /// récupère les represnetation d'une salle
        /// </summary>
        /// <param name="IdSalle">identifiant de la  salle</param>
        /// <returns>une liste de represnetation</returns>
        Task<IEnumerable<RepresentationDto>> GetRepresentationFromSalle(int IdSalle);
        /// <summary>
        /// récupère les piece de theatre liée a une complexe de theatre
        /// </summary>
        /// <param name="IdPiece">l'identifiant du complexe</param>
        /// <returns>une liste de piece</returns>
        
    }
}
