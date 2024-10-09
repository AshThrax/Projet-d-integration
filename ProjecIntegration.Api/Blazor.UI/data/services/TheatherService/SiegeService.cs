using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.TheatherService
{
    public interface ISiegeService
    {
        Task<IEnumerable<SiegeDto>> GetAllFromsalleId(int siegeId);
        Task<Pagination<SiegeDto>> GetAllFromsalleId(int siegeId,int page);
        Task<IEnumerable<SiegeDto>> GetAllFromCommandId(int commandId);
        Task<SiegeDto> GetById(int siegeId);
        Task Create(AddSiegeDto siegeDto);
        Task Update(int updtId, UpdateSiegeDto siegeDto);
        Task Delete(int siegeId);
    }
    public class SiegeService : ISiegeService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUri = "https://localhost:7170/api/v1/Siege";

        public SiegeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(AddSiegeDto siegeDto)
        {
            await _httpClient.PostAsJsonAsync<AddSiegeDto>(ApiUri, siegeDto);
        }

        public async Task Delete(int siegeId)
        {
            await _httpClient.DeleteAsync(ApiUri + $"/{siegeId}");
        }

        public async Task<IEnumerable<SiegeDto>> GetAllFromCommandId(int commandId)
        {
            var response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<SiegeDto>>>(ApiUri +$"/from-command/{commandId}");
            return response.Data;
        }

        public async Task<IEnumerable<SiegeDto>> GetAllFromsalleId(int siegeId)
        {
            var response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<SiegeDto>>>(ApiUri +$"/from-salle/{siegeId}");
            return response.Data;
        }
        public async Task<Pagination<SiegeDto>> GetAllFromsalleId(int siegeId,int page)
        {
            var response = await _httpClient.GetFromJsonAsync<Pagination<SiegeDto>>(ApiUri + $"/from-salle/{siegeId}/{page}");
            return response;
        }
        public async Task<SiegeDto> GetById(int siegeId)
        {
          return  (await _httpClient.GetFromJsonAsync<ServiceResponse<SiegeDto>>(ApiUri + $"/{siegeId}")).Data;
        }

        public async Task Update(int updtId, UpdateSiegeDto siegeDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSiegeDto>(ApiUri + $"/{updtId}",siegeDto);
        }
    }
}
