using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ServiceResponse;
using ApplicationTheather.DTO;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessCatalogue
    {
        Task<ServiceResponse<IEnumerable<CatalogueDto>>> GetAllCatalogue();
        /// <summary>
        /// récupération d'un catalogue par id 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <returns></returns>
        Task<ServiceResponse<CatalogueDto>> GetCatalogueById(int catalogueId);
        /// <summary>
        /// récupération d'une serie de catalogue sur base de l'identifiant
        /// du catalogue 
        /// </summary>
        /// <param name="complexeId"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<CatalogueDto>>> GetCatalogueByComplexe(int complexeId);
        /// <summary>
        /// supression d'un catalogue sur base de son Id
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <returns></returns>
        Task<ServiceResponse<CatalogueDto>> DeleteCatalogue(int catalogueId);
        /// <summary>
        /// ajout d'une piece a un catalogue 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <param name="PieceId"></param>
        /// <returns></returns>
        Task<ServiceResponse<CatalogueDto>> AddPieceToCatalogue(int  catalogueId, int PieceId);
        /// <summary>
        /// enlève une piece compris dans uncatalogue 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <param name="PieceId"></param>
        /// <returns></returns>
        Task<ServiceResponse<CatalogueDto>> RemovePieceToCataogue(int catalogueId, int PieceId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCatalogue"></param>
        /// <returns></returns>
        Task<ServiceResponse<CatalogueDto>> CreateCatalogue(AddCatalogueDto addCatalogue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCatalogue"></param>
        /// <returns></returns>
        Task<ServiceResponse<CatalogueDto>> UpdateCatalogue(int catalogueId,UpdateCatalogueDto addCatalogue);
    }
}
