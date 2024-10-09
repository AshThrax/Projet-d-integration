
using Blazor.UI.Data.ModelViews.Publication;
using Blazor.UI.Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.data.services.Publication
{
    public interface IPostService
    {
        Task<Pagination<PostDto>> GetAllByPublicationId(string publicationId,int Index);

        Task<PostDto> GetPostById(string postId);
        Task DeletePost(string postId);
        Task UpdatePost(string Id, UpdatePostDto post);
        Task CreatePost(string publicationId,AddPostDto post);
        Task<bool> IsAuthor(string postId);
    }
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Post";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePost(string publicationId, AddPostDto post)
        {
            await _httpClient.PostAsJsonAsync<AddPostDto>($"{ApiUri}/{publicationId}", post);
        }

        public async Task DeletePost(string postId)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{postId}");
        }

        public async Task<Pagination<PostDto>?> GetAllByPublicationId(string publicationId,int Index)
        {
            try
            {

                return await _httpClient.GetFromJsonAsync<Pagination<PostDto>?>($"{ApiUri}/publication-all/{publicationId}/{Index}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PostDto?> GetPostById(string postId)
        {
           return await _httpClient.GetFromJsonAsync<PostDto>($"{ApiUri}/{postId}");
        }

        public async Task UpdatePost(UpdatePostDto post)
        {
            await _httpClient.PutAsJsonAsync<UpdatePostDto>($"{ApiUri}/{post.Id}",post);
        }

        public async Task<bool> IsAuthor(string postId)
        {
            return await _httpClient.GetFromJsonAsync<bool>(ApiUri + $"/iswriter/{postId}");
        }
    }

}
