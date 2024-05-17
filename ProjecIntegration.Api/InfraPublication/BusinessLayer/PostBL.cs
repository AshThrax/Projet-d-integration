using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
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
        private readonly IMapper _mapper;

        public PostBL(IPostRepository postrepository, IMapper mapper)
        {
            _postrepository = postrepository;
          
            _mapper = mapper;
        }

        public async Task Createasync(string publicationId,PostDto pub)
        {
            try
            {
                
                  if (string.IsNullOrEmpty(publicationId))
                  {
                      Post mapped= _mapper.Map<Post>(pub);
                      mapped.UpdatedDate = DateTime.Now;
                      mapped.CreatedDate = DateTime.Now;
                      _postrepository.Insert(mapped);
                  }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task DeletePost(string postId)
        {
            try
             { 
                Post Getdeleted=await _postrepository.GetById(postId)
                                                     ?? throw new NullReferenceException("null reference");
                if (Getdeleted != null)
                {
                    _postrepository.Delete(postId);
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public Task<IEnumerable<PostDto>> GetAllPostFromPUblicationId(string PubId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostById(string postId)
        {
            try
            {
                Post Getdeleted = await _postrepository.GetById(postId) ?? throw new NullReferenceException("null reference");
                if (Getdeleted != null)
                {
                    return Getdeleted;
                }
                return new Post();

            }
            catch (Exception)
            {

                return new Post();

            }
        }

        public async Task UpdatePost(string postId, string content)
        {
            try
            {
              Post Getdeleted = await _postrepository.GetById(postId) ?? throw new NullReferenceException("null reference");
              if (Getdeleted != null)
              {
               await _postrepository.Update(postId,content);
              }
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }
    }
}
