using Blazor.UI.Data.ModelViews.Theater;
using Data.ServiceResult;
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
        private const string ApiUri = "https://localhost:7170/api/v1/Catalogue";

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

        public async Task<IEnumerable<CatalogueDto>?> GetAllCatalogue()
        {
            ServiceResponse<IEnumerable<CatalogueDto>>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<CatalogueDto>>>($"{ApiUri}");

            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CatalogueDto>?> GetAllCatalogueByComplexeId(int complexeId)
        {
            ServiceResponse<IEnumerable<CatalogueDto>>? response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<CatalogueDto>>>($"{ApiUri}/complexe/{complexeId}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<CatalogueDto?> GetCatalogue(int catalogueId)
        {
            ServiceResponse < CatalogueDto >? response= await _httpClient.GetFromJsonAsync<ServiceResponse<CatalogueDto>>($"{ApiUri}/{catalogueId}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

      

        public async Task UpdateCatalogue(int catalogueId, UpdateCatalogueDto catalogue)
        {
            await _httpClient.PutAsJsonAsync<UpdateCatalogueDto>($"{ApiUri}/{catalogueId}",catalogue);
        }
    }
}
