using Blazor.UI.Client.Page;
using Blazor.UI.Data.modelViews.Theater;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface IComplexeService
    {
        Task<IEnumerable<ComplexeDto>> Get();
        Task<ComplexeDto> GetById(int id);
        Task Create(AddComplexeDto data);
        Task Update(int id, UpdateComplexeDto data);
        Task Delete(int id);
        Task AddSalle(int id, AddSalleDeTheatreDto data);
    }
    public class ComplexeService : IComplexeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/v1/Complexe";

        public ComplexeService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<ComplexeDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ComplexeDto>>(ApiUri);
        }

        public async Task<ComplexeDto?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ComplexeDto?>($"{ApiUri}/{id}");
        }

        public async Task Create(AddComplexeDto data)
        {
            await _httpClient.PostAsJsonAsync($"{ApiUri}", data);
        }

        public async Task Update(int id, UpdateComplexeDto data)
        {
            await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{id}");
        }

        public async Task AddSalle(int id, AddSalleDeTheatreDto data)
        {
            await _httpClient.PostAsJsonAsync($"{ApiUri}/{id}", data);
        }
    }
}