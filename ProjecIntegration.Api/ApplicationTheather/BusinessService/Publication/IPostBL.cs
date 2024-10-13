using ApplicationPublication.Dto;
using Domain.ServiceResponse;

namespace InfraPublication.BusinessService
{
    public interface IPostBL
    {
        Task<ServiceResponse<PostDto>> CreateAsync(int publicationId, AddPostDto pub);
        Task<ServiceResponse<PostDto>> DeletePost(int postId);
        Task<ServiceResponse<IEnumerable<PostDto>>> GetAllPostFromPublicationId(int PubId);
        Task<ServiceResponse<PostDto>> GetPostById(int postId);
        Task<ServiceResponse<IEnumerable<PostDto>>> GetPostFromUserId(string userId);
        Task<bool> IsAuthor(int postId, string userId);
        Task<ServiceResponse<PostDto>> UpdatePost(int postId, string content);
    }
}