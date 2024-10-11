using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Blazored.Toast.Services;
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
        private readonly IToastService _toastService;
        public SalleService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
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
            var result =await _httpClient.PostAsJsonAsync(ApiUri, data);
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

        public async Task AddPiece(int idSalle, AddPieceDto data)
        {
            var result=await _httpClient.PostAsJsonAsync($"{ApiUri}/add-piece/{idSalle}", data);
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

        public async Task Update(int id, UpdateSalleDeTheatreDto data)
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
            var result=await _httpClient.DeleteAsync($"{ApiUri}/{id}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been removed");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }
    }
}