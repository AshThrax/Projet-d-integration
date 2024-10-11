using Blazor.UI.Data.ModelViews.Theater;
using Blazored.Toast.Services;
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
        private readonly IToastService _toastService;
        private const string ApiUri = "https://localhost:7170/api/v1/Complexe";

        public ComplexeService(HttpClient httpClient,IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;

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
            var result= await _httpClient.PostAsJsonAsync($"{ApiUri}", data);
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

        public async Task Update(int id, UpdateComplexeDto data)
        {
            var result =await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
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

        public async Task Delete(int id)
        {
           var result= await _httpClient.DeleteAsync($"{ApiUri}/{id}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been delete");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task AddSalle(int id, AddSalleDeTheatreDto data)
        {
            var result =await _httpClient.PostAsJsonAsync($"{ApiUri}/{id}", data);
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
    }
}