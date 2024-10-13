using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using Domain.Enum;
using Domain.ServiceResponse;
using MongoDB.Bson;

namespace InfraPublication.BusinessService
{
    public class PostBL : IPostBL
    {
        private readonly IPostRepository _postrepository;
        private readonly IPublicationRepository _publicationrepository;
        private readonly IMapper _mapper;

        public PostBL(IPostRepository postrepository, IPublicationRepository publicationRepository, IMapper mapper)
        {
            _postrepository = postrepository;
            _publicationrepository = publicationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PostDto>> CreateAsync(int publicationId, AddPostDto pub)
        {
            ServiceResponse<PostDto> response = new();
            try
            {

                if (publicationId<0)
                {
                    throw new ArgumentException("");
                }
                Publication? publication = await _publicationrepository.GetById(publicationId)
                                                          ?? throw new NullReferenceException();
                Post mapped = _mapper.Map<Post>(pub);


           
                response.Success = true;
                response.Message = "operation sucess";
                response.Errortype = Errortype.Good;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<PostDto>> DeletePost(int postId)
        {
            ServiceResponse<PostDto> response = new();
            try
            {
                Post Getdeleted = await _postrepository.GetById(postId)
                                                     ?? throw new NullReferenceException("null reference");

                await _postrepository.Delete(postId);
                response.Success = true;
                response.Message = "operation sucess";
                response.Errortype = Errortype.Good;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<PostDto>>> GetAllPostFromPublicationId(int PubId)
        {
            ServiceResponse<IEnumerable<PostDto>> response = new();
            try
            {
                IEnumerable<Post> post = await _postrepository.GetAllFromPublication(PubId);
                response.Data = _mapper.Map<IEnumerable<PostDto>>(post);
                response.Success = true;
                response.Message = "operation sucess";
                response.Errortype = Errortype.Good;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<PostDto>> GetPostById(int postId)
        {
            ServiceResponse<PostDto> response = new();
            try
            {
                Post GetPosted = await _postrepository.GetById(postId) ?? throw new NullReferenceException("null reference");
                response.Data = _mapper.Map<PostDto>(GetPosted);
                response.Success = true;
                response.Message = "operation sucess";
                response.Errortype = Errortype.Good;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<PostDto>>> GetPostFromUserId(string userId)
        {
            ServiceResponse<IEnumerable<PostDto>> response = new ServiceResponse<IEnumerable<PostDto>>();
            try
            {
                IEnumerable<Post> post = await _postrepository.GetAllFromUserId(userId);
                response.Data = _mapper.Map<IEnumerable<PostDto>>(post);
                response.Success = true;
                response.Errortype = Errortype.Good;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }

        public async Task<bool> IsAuthor(int postId, string userId)
        {
            try
            {
                Post? getPost = await _postrepository.GetById(postId);
                return (getPost.UserId.Equals(userId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<PostDto>> UpdatePost(int postId, string content)
        {
            ServiceResponse<PostDto> response = new ServiceResponse<PostDto>();
            try
            {
                Post Getdeleted = await _postrepository.GetById(postId) ?? throw new NullReferenceException("null reference");
                if (Getdeleted == null)
                {
                    throw new ArgumentException("argument null inside de data");
                }
                await _postrepository.Update(postId, content);
                response.Success = true;
                response.Errortype = Errortype.Good;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;

        }
    }
}
