using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Common.Repository;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.BusinessLayer
{
    public class PublicationBL : IPublicationBl
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IPostRepository _postRepository;

        public PublicationBL(IPublicationRepository publicationRepository, IPostRepository postRepository)
        {
            _publicationRepository = publicationRepository;
            _postRepository = postRepository;
        }

        #region publication
        public Task CreatePublication(Publication pub)
        {
            throw new NotImplementedException();
        }

        public Task DeletePublication(string pubId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Publication>> GetAllbyPublicationID(string userId)
        {
            throw new NotImplementedException();
        }
        public Task<Publication> GetPublicationById(string pubId)
        {
            throw new NotImplementedException();
        } 
        public Task UpdatePublication(string pubId, Publication pub)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region post
        public Task UpdatePost(string postId, Post post)
        {
            throw new NotImplementedException();
        }
        public Task Createasync(Post pub)
        {
              throw new NotImplementedException();
        }
        public Task DeletePost(string postId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Post>> GetAllPostFromPUblicationId(string PubId)
        {
            throw new NotImplementedException();
        }
        public Task<Post> GetPostById(string postId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region repost
        public Task<Post> GetRePostById(string repostId)
        {
            throw new NotImplementedException();
        }
        public Task CreateAsync(RePost pub)
        {
                    throw new NotImplementedException();
        }
        public Task DeleteRePost(string repostId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Post>> GetAllRePostFromPostId(string PostId)
        {
            throw new NotImplementedException();
        }
        public Task UpdatePost(string repostId, RePost post)
        {
            throw new NotImplementedException();
        }
        #endregion

           

       
    }
}
