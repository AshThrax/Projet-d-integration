using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessSalle
    {
        /// <summary>
        /// Crée une salle affilié au complexe correspondant 
        /// </summary>
        /// <param name="idComplexe">identifiant du complexe</param>
        /// <param name="entity">nouvvelle salled e hteatre</param>
        /// <returns></returns>
        Task<ServiceResponse<SalleDeTheatreDto>> CreateSalle(int idComplexe, AddSalleDeTheatreDto entity);
        /// <summary>
        ///  supprimer une salle de theatre
        /// </summary>
        /// <param name="idSalle">identifiant de la sallede theatre</param>
        /// <returns></returns>
        Task<ServiceResponse<SalleDeTheatreDto>> DeleteSalle(int idSalle);
        /// <summary>
        /// mets a jour une salle de theatre
        /// </summary>
        /// <param name="idSalle">l'identifiant de la salle de theatre</param>
        /// <param name="entity">salle de theatre a mettre a jour</param>
        /// <returns></returns>
        Task<ServiceResponse<SalleDeTheatreDto>> Updatesalle(int idSalle, UpdateSalleDeTheatreDto entity);
        /// <summary>
        /// recupére toutes les salles present en database
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<SalleDeTheatreDto>>> GetAllSalle();
        /// <summary>
        /// récupère une salle en fonction de son identifiant 
        /// </summary>
        /// <param name="idSalle"></param>
        /// <returns>récupère une sallede teheatre</returns>
        Task<ServiceResponse<SalleDeTheatreDto>> GetSalle(int idSalle);
        /// <summary>
        /// récupère toutes les salle liée a un complexe 
        /// </summary>
        /// <param name="idComplexe"></param>
        /// <returns>une liste de salle de theatre affiliée a un complexe</returns>
        Task<ServiceResponse<IEnumerable<SalleDeTheatreDto>>> GetFromComplexe(int idComplexe);

    
    }
}
