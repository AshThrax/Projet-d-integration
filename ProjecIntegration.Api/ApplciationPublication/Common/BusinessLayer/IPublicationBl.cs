using ApplicationPublication.Dto;
using Domain.Entity.publicationEntity;
using Domain.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.BusinessLayer
{
    public interface IPublicationBl
    {
        #region publication
        Task<ServiceResponse<PublicationDto>> DeletePublication(string pubId);
        Task<ServiceResponse<IEnumerable<PublicationDto>>> GetAllPublication();
        Task<ServiceResponse<PublicationDto>> GetPublicationById(string pubId);
        Task<ServiceResponse<IEnumerable<PublicationDto>>> GetPublicationByPiece(int pieceId);
        Task<ServiceResponse<IEnumerable<PublicationDto>>> GetAllbyPublicationByUserId(string userId);
        Task<ServiceResponse<PublicationDto>> CreatePublication(AddPublicationDto pub);
        Task<ServiceResponse<PublicationDto>> UpdatePublication(string pubId,string Title, string content);
        Task<bool> IsAuthor(string pubId, string userId);
        Task<bool> Hasreview(int pieceId, string userId);
        #endregion

    }
}
