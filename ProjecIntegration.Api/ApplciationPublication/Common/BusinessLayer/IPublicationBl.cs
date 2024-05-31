using ApplicationPublication.Dto;
using Domain.Entity.publicationEntity;
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
        Task DeletePublication(string pubId);
        Task<IEnumerable<PublicationDto>> GetAllPublication();
        Task<PublicationDto> GetPublicationById(string pubId);
        Task<IEnumerable<PublicationDto>> GetPublicationByPiece(int pieceId);
        Task<IEnumerable<PublicationDto>> GetAllbyPublicationByUserId(string userId);
        Task CreatePublication(AddPublicationDto pub);
        Task UpdatePublication(string pubId,string Title, string content);
        #endregion

    }
}
