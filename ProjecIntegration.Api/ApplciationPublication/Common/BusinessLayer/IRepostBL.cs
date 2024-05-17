using ApplicationPublication.Dto;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.BusinessLayer
{
    public interface IRepostBL
    {
        #region repost
        Task DeleteRePost(string repostId);
        Task UpdatePost(string repostId, RepostDto post);
        Task CreateAsync(RepostDto pub);
        Task<RepostDto> GetRePostById(string repostId);
        Task<IEnumerable<RepostDto>> GetAllRePostFromPostId(string PostId);
        #endregion
    }
}
