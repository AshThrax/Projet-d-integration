
using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Blazored.Toast.Services;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface IRepresentationService
    {

        Task<Pagination<RepresentationDto>> Get(int page);
        Task<RepresentationDto> GetById(int id);
        Task Create(AddRepresentationDto data);
        Task Update(UpdateRepresentationDto data);
        Task Delete(int id);
        Task<Pagination<RepresentationDto>> GetSalle(int idSalle,int page);
        Task<Pagination<RepresentationDto>> GetPiece(int idPiece,int page);
        Task AddCommandRepresentation(int id, int idPlace, AddCommandDto data);
        Task DeleteCommandRepresentation(int idRep, int idCommand);
    }

    public class RepresentationService : IRepresentationService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Representation";
        private readonly IToastService _toastService;
        public RepresentationService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<Pagination<RepresentationDto>?> Get(int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<RepresentationDto>>($"{ApiUri}/{page}");
        }

        public async Task<RepresentationDto?> GetById(int id)
        {
            ServiceResponse<RepresentationDto>? response = await _httpClient.GetFromJsonAsync<ServiceResponse<RepresentationDto>?>($"{ApiUri}/{id}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task Create(AddRepresentationDto data)
        {
            var result=await _httpClient.PostAsJsonAsync<AddRepresentationDto>(ApiUri, data);
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

        public async Task Update(UpdateRepresentationDto data)
        {
            var result=await _httpClient.PutAsJsonAsync<UpdateRepresentationDto>(ApiUri+$"/{data.Id}", data);
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
            var result =await _httpClient.DeleteAsync($"{ApiUri}/{id}");
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

        public async Task<Pagination<RepresentationDto>?> GetSalle(int idSalle,int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<RepresentationDto>?>($"{ApiUri}/from-salle/{idSalle}/{page}");
        }

        public async Task<Pagination<RepresentationDto>?> GetPiece(int idPiece,int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<RepresentationDto>>($"{ApiUri}/from-piece/{idPiece}/{page}");
        }

        public async Task AddCommandRepresentation(int id, int idplace, AddCommandDto data)
        {
            var result =await _httpClient.PostAsJsonAsync($"https://localhost:7170/api/Representation/add-command/{id}/{idplace}", data);
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

        public async Task DeleteCommandRepresentation(int idRep, int idCommand)
        {
            var result =await _httpClient.DeleteAsync($"{ApiUri}/delete-command/{idRep}/{idCommand}");
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
