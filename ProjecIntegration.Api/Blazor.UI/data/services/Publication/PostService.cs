using Blazor.UI.Data.modelViews.Publication;
using System.Net.Http.Json;

namespace Blazor.UI.data.services.Publication
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllByPublicationId(string publicationId);

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

        public async Task<IEnumerable<PostDto>?> GetAllByPublicationId(string publicationId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PostDto>?>($"{ApiUri}/publication-all/{publicationId}");
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
