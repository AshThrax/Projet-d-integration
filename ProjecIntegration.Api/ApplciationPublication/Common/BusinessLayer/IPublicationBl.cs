using ApplciationPublication.Dto;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Common.BusinessLayer
{
    public interface IPublicationBl
    {
        #region publication
        Task DeletePublication(string pubId);
        Task<IEnumerable<PublicationDto>> GetAllPublication();
        Task<PublicationDto> GetPublicationById(string pubId);
        Task<IEnumerable<PublicationDto>> GetAllbyPublicationID(string userId);
        Task CreatePublication(PublicationDto pub);
        Task UpdatePublication(string pubId,string content);
        #endregion
      
    }
}
