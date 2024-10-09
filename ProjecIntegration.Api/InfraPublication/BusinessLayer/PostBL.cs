using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using MongoDB.Bson;
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
        private readonly IPublicationRepository _publicationrepository;
        private readonly IMapper _mapper;

        public PostBL(IPostRepository postrepository,IPublicationRepository publicationRepository, IMapper mapper)
        {
            _postrepository = postrepository;
            _publicationrepository = publicationRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(string publicationId,AddPostDto pub)
        {
            try
            {
                
                  if (!string.IsNullOrEmpty(publicationId))
                  {
                      Publication? publication = await _publicationrepository.GetById(publicationId) 
                                                                ?? throw new NullReferenceException(); 
                      Post mapped= _mapper.Map<Post>(pub);


                      //creation de l'objet de type de post
                      mapped.PublicationId = publicationId;
                      mapped.Id = ObjectId.GenerateNewId().ToString();
                      mapped.UpdatedDate = DateTime.Now;
                      mapped.CreatedDate = DateTime.Now;
                      publication?.post.Add(mapped.Id);
                      await _publicationrepository.Update(publicationId,publication);
                      await _postrepository.Insert(mapped);
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
                    await _postrepository.Delete(postId);
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<PostDto>> GetAllPostFromPublicationId(string PubId)
        {
            try
            {
                IEnumerable<Post> post = await _postrepository.GetAllFromPublication(PubId);
                return _mapper.Map<IEnumerable<PostDto>>(post);
            }
            catch (Exception)
            {

                throw;
            }
            
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

        public async  Task<IEnumerable<PostDto>> GetPostFromUserId(string userId)
        {
            try
            {
                IEnumerable<Post> post = await _postrepository.GetAllFromUserId(userId);
                return _mapper.Map<IEnumerable<PostDto>>(post);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsAuthor(string postId, string userId)
        {
            try
            {
                Post? getPost = await _postrepository.GetById(postId);
                return(getPost.UserId.Equals(userId));
            }
            catch (Exception)
            {

                throw;
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
