using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Common.Repository;
using ApplciationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.BusinessLayer
{
    public class PostBL : IPostBL
    {
        private readonly IPostRepository _postrepository;
        private readonly IPublicationRepository _publicationBL;
        private readonly IMapper _mapper;

        public PostBL(IPostRepository postrepository, IPublicationRepository publicationBL, IMapper mapper)
        {
            this._postrepository = postrepository;
            _postrepository = postrepository;
            _mapper = mapper;
        }

        public async Task Createasync(string publicationId,PostDto pub)
        {
            if (pub != null)
            {
                var mapped= _mapper.Map<Post>(pub);
                _postrepository.Insert(mapped);
            }
        }

        public async Task DeletePost(string postId)
        {
            var Getdeleted=await _postrepository.GetById(postId);
            if (Getdeleted != null)
            {
                _postrepository.Delete(postId);
            }
        }

        public Task<IEnumerable<PostDto>> GetAllPostFromPUblicationId(string PubId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostById(string postId)
        {
            var Getdeleted = await _postrepository.GetById(postId);
            if (Getdeleted != null)
            {
                return Getdeleted;
            }
            return null;
        }

        public async Task UpdatePost(string postId, string content)
        {
            var Getdeleted = await _postrepository.GetById(postId);
            if (Getdeleted != null)
            {
                
                await _postrepository.Update(postId,content);
            }
           
        }
    }
}
