using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface ISalleService
    {
        Task<Pagination<SalleDeTheatreDto>> Get(int Id,int page);
        Task<IEnumerable<SalleDeTheatreDto>> Getlist();
        Task<SalleDeTheatreDto> GetById(int id);
        Task Create(AddSalleDeTheatreDto data);
        Task AddPiece(int idSalle, AddPieceDto data);
        Task Update(int id, UpdateSalleDeTheatreDto data);
        Task Delete(int id);
    }
    public class SalleService : ISalleService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/SallesDeTheatre";

        public SalleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pagination<SalleDeTheatreDto>?> Get(int Id, int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<SalleDeTheatreDto>?>(ApiUri+ $"/get-complexe/{Id}/{page}");

        }
        public async Task<IEnumerable<SalleDeTheatreDto>?> Getlist()
        {
            ServiceResponse<IEnumerable<SalleDeTheatreDto>>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<SalleDeTheatreDto>>?>($"{ApiUri}/list");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<SalleDeTheatreDto?> GetById(int id)
        {
            ServiceResponse<SalleDeTheatreDto>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<SalleDeTheatreDto>?>($"{ApiUri}/single/{id}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task Create(AddSalleDeTheatreDto data)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, data);
        }

        public async Task AddPiece(int idSalle, AddPieceDto data)
        {
            await _httpClient.PostAsJsonAsync($"{ApiUri}/add-piece/{idSalle}", data);
        }

        public async Task Update(int id, UpdateSalleDeTheatreDto data)
        {
            await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{id}");
        }
    }
}