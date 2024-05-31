using Blazor.UI.Data.modelViews.Theater;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface ICatalogueService
    {
        Task AddCatalogue(CatalogueDto catalogueDto);
        Task DeleteCatalogue(int catalogueId);
        Task<CatalogueDto> GetCatalogue(int catalogueId);
        Task UpdateCatalogue(int catalogueId, UpdateCatalogueDto catalogue);
        Task<IEnumerable<CatalogueDto>> GetAllCatalogue();
        Task<IEnumerable<CatalogueDto>> GetAllCatalogueByComplexeId(int complexeId);
    }
    public class CataloguesService : ICatalogueService
    {

        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/v1/Catalogue";

        public CataloguesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddCatalogue(CatalogueDto catalogueDto)
        {
            await _httpClient.PostAsJsonAsync<CatalogueDto>($"{ApiUri}", catalogueDto);
        }

        public async  Task DeleteCatalogue(int catalogueId)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{catalogueId}");
        }

        public async Task<IEnumerable<CatalogueDto>> GetAllCatalogue()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CatalogueDto>>($"{ApiUri}");
        }

        public async Task<IEnumerable<CatalogueDto>> GetAllCatalogueByComplexeId(int complexeId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CatalogueDto>>($"{ApiUri}/complexe/{complexeId}");
        }

        public async Task<CatalogueDto> GetCatalogue(int catalogueId)
        {
            return await _httpClient.GetFromJsonAsync<CatalogueDto>($"{ApiUri}/{catalogueId}");
        }

      

        public async Task UpdateCatalogue(int catalogueId, UpdateCatalogueDto catalogue)
        {
            await _httpClient.PutAsJsonAsync<UpdateCatalogueDto>($"{ApiUri}/{catalogueId}",catalogue);
        }
    }
}
