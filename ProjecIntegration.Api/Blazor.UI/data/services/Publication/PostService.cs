using Blazor.UI.data.modelViews;

namespace Blazor.UI.data.services.Publication
{
    public interface IPostService
    {
        Task<PostDto> GetAllByPublicationId(string publicationId);

        Task<PostDto> GetPostById(string postId);
        Task DeletePost(string postId);
        Task UpdatePost(PostDto post);
        Task CreatePost(PostDto post);
    }
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/V1/Post";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreatePost(PostDto post)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetAllByPublicationId(string publicationId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPostById(string postId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePost(PostDto post)
        {
            throw new NotImplementedException();
        }
    }
}
