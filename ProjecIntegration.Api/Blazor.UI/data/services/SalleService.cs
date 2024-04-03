using Blazor.UI.data.modelViews;
using System.Net.Http.Json;

namespace Blazor.UI.data.services
{
    public interface ISalleService
    {
        Task<IEnumerable<SalleDeTheatreDto>> Get();
        Task<SalleDeTheatreDto> GetById(int id);
        Task Create(AddSalleDeTheatreDto data);
        Task AddPiece(int idSalle, AddPieceDto data);
        Task Update(int id, UpdateSalleDeTheatreDto data);
        Task Delete(int id);
    }
    public class SalleService : ISalleService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/SallesDeTheatre";

        public SalleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SalleDeTheatreDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SalleDeTheatreDto>>(ApiUri);
        }

        public async Task<SalleDeTheatreDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SalleDeTheatreDto>($"{ApiUri}/{id}");
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