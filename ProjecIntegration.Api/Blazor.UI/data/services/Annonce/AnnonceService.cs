
using Blazor.UI.Data.ModelViews.Annonce;
using Blazor.UI.Data.ServiceResult;
using System.Net.Http.Json;
namespace Blazor.UI.Data.services.Annonce
{
    public interface IAnnonceService
    {
        Task<AnnonceDto> GetAnnonceById(string Id);
        Task<Pagination<AnnonceDto>> GetAll(int page);
        Task UpdateAnnonce(string annonceId, UpdateAnnonceDto annonce);
        Task CreateAnnonce(AddAnnonceDto annonceDto);
        Task DeleteAnnonce(string annonceId);
    }
    public class AnnonceService : IAnnonceService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Annonce";

        public AnnonceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAnnonce(AddAnnonceDto annonceDto)
        {
            await _httpClient.PostAsJsonAsync<AddAnnonceDto>(ApiUri, annonceDto);
        }

        public async Task DeleteAnnonce(string annonceId)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{annonceId}");
        }

        public async Task<Pagination<AnnonceDto>?> GetAll(int page)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Pagination<AnnonceDto>>(ApiUri+$"/page/{page}");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AnnonceDto?> GetAnnonceById(string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<AnnonceDto?>($"{ApiUri}/{id}");

            }
            catch (Exception)
            {
                return new AnnonceDto();
            }
        }

        public async Task UpdateAnnonce(string id, UpdateAnnonceDto annonceDto)
        {
            
            await _httpClient.PutAsJsonAsync<UpdateAnnonceDto>($"{ApiUri}/{id}", annonceDto);
        }


    }
}
