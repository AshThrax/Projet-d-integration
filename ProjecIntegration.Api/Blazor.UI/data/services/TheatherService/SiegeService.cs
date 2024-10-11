using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Blazored.Toast.Services;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.TheatherService
{
    public interface ISiegeService
    {
        Task<IEnumerable<SiegeDto>> GetAllFromsalleId(int siegeId);
        Task<Pagination<SiegeDto>> GetAllFromsalleId(int siegeId,int page);
        Task<IEnumerable<SiegeDto>> GetAllFromCommandId(int commandId);
        Task<IEnumerable<SiegeDto>> GetAllAvailableSiegeFromRepresentation(int representationId, int salleId);
        Task<SiegeDto> GetById(int siegeId);
        Task Create(AddSiegeDto siegeDto);
        Task Update(int updtId, UpdateSiegeDto siegeDto);
        Task Delete(int siegeId);
    }
    public class SiegeService : ISiegeService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly string ApiUri = "https://localhost:7170/api/v1/Siege";

        public SiegeService(HttpClient httpClient,IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task Create(AddSiegeDto siegeDto)
        {
            var result=await _httpClient.PostAsJsonAsync<AddSiegeDto>(ApiUri, siegeDto);
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been added");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task Delete(int siegeId)
        {
            var result=await _httpClient.DeleteAsync(ApiUri + $"/{siegeId}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been Deleted");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task<IEnumerable<SiegeDto>> GetAllFromCommandId(int commandId)
        {
            var response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<SiegeDto>>>(ApiUri +$"/from-command/{commandId}");
            return response.Data;
        }
        public async Task<IEnumerable<SiegeDto>> GetAllAvailableSiegeFromRepresentation(int representationId,int salleId)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<SiegeDto>>>(ApiUri + $"/representation/available/{representationId}/{salleId}");
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
            var result=await _httpClient.PutAsJsonAsync<UpdateSiegeDto>(ApiUri + $"/{updtId}",siegeDto);
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been updated");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }
    }
}
