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
        Task<Publication> GetPublicationById(string pubId);
        Task<IEnumerable<Publication>> GetAllbyPublicationID(string userId);
        Task CreatePublication(Publication pub);
        Task UpdatePublication(string pubId,Publication pub);
        #endregion

        #region post
        Task DeletePost(string postId);
        Task<Post> GetPostById(string postId);
        Task<IEnumerable<Post>> GetAllPostFromPUblicationId(string PubId);
        Task UpdatePost(string postId, Post post);
        Task Createasync(Post pub);
        #endregion

        #region repost
        Task DeleteRePost(string repostId);
        Task UpdatePost(string repostId, RePost post);
        Task CreateAsync(RePost pub);
        Task<Post> GetRePostById(string repostId);
        Task<IEnumerable<Post>> GetAllRePostFromPostId(string PostId);
        #endregion
    }
}
