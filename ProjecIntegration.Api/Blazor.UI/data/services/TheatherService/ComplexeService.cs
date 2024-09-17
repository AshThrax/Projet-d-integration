using Blazor.UI.Data.ModelViews.Theater;
using Data.ServiceResult;
using System.Net.Http.Json;

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

        public async Task<IEnumerable<ComplexeDto>?> Get()
        {
            try
            {
                ServiceResponse<IEnumerable<ComplexeDto>>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<ComplexeDto>>>(ApiUri);

                if (response.Success)
                {
                   return response.Data;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

               return new List<ComplexeDto>();
            }
        }

        public async Task<ComplexeDto?> GetById(int id)
        {
            try
            {
                ServiceResponse<ComplexeDto>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<ComplexeDto>?>($"{ApiUri}/{id}");
                if (response.Success)
                {
                    return response.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

              return new ComplexeDto();
            }
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