using Blazor.UI.Data.modelViews.Publication;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.Publication
{
    public interface IPublicationService
    {
        Task AddPublication(PublicationDto catalogueDto);
        Task DeletePublication(string catalogueId);
        Task<PublicationDto> GetPublication(int catalogueId);
        Task<PublicationDto> UpdatePublication(int catalogueId, PublicationDto catalogue);
        Task<IEnumerable<PublicationDto>> GetPublicationByUserId();
        Task<IEnumerable<PublicationDto>> GetAllPublicationByPieceId(int id);

        //--------------------------------------------------

    }
    public class PublicationService : IPublicationService
    {

        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/v1/Publication";

        public PublicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddPublication(PublicationDto catalogueDto)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, catalogueDto);
        }

        public async Task DeletePublication(string catalogueId)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{catalogueId}");
        }

        public async Task<PublicationDto?> GetPublication(int catalogueId)
        {
            return await _httpClient.GetFromJsonAsync<PublicationDto>($"{ApiUri}/{catalogueId}");
        }

        public Task<PublicationDto> UpdatePublication(int catalogueId, PublicationDto catalogue)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PublicationDto>?> GetPublicationByUserId()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PublicationDto>?>($"{ApiUri}");
        }

        public async Task<IEnumerable<PublicationDto>?> GetAllPublicationByPieceId(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PublicationDto>?>($"{ApiUri}/{id}");
        }
    }
}
