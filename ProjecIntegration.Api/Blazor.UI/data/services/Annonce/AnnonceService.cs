using Blazor.UI.data.modelViews.Annonce;
using System.Net.Http.Json;
namespace Blazor.UI.Data.services.Annonce
{
    public interface IAnnonceService
    {
        Task<AnnonceDto> GetAnnonceById(string Id);
        Task<IEnumerable<AnnonceDto>> GetAll();
        Task UpdateAnnonce(string annonceId, AnnonceDto annonce);
        Task CreateAnnonce(AnnonceDto annonceDto);
        Task DeleteAnnonce(string annonceId);
    }
    public class AnnonceService : IAnnonceService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/v1/annonce";

        public AnnonceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAnnonce(AnnonceDto annonceDto)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, annonceDto);
        }

        public async Task DeleteAnnonce(string annonceId)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{annonceId}");
        }

        public async Task<IEnumerable<AnnonceDto>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<AnnonceDto[]?>(ApiUri);
        }

        public async Task<AnnonceDto?> GetAnnonceById(string id)
        {
            return await _httpClient.GetFromJsonAsync<AnnonceDto?>($"{ApiUri}/{id}");
        }

        public async Task UpdateAnnonce(string id, AnnonceDto annonceDto)
        {

            await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", annonceDto);
        }


    }
}
