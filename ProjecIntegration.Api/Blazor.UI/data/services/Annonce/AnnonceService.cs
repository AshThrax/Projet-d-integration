
using Blazor.UI.Data.ModelViews.Annonce;
using Blazor.UI.Data.ServiceResult;
using Blazored.Toast.Services;
using System.Net.Http.Json;
namespace Blazor.UI.Data.services.Annonce
{
    public interface IAnnonceService
    {
        Task<AnnonceDto> GetAnnonceById(string Id);
        Task<Pagination<AnnonceDto>> GetAll(int page);
        Task UpdateAnnonce(string annonceId, UpdateAnnonceDto annonce);
        Task CreateAnnonce(AddAnnonceDto annonceDto);
        Task DeleteAnnonce(string annonceId);
    }
    public class AnnonceService : IAnnonceService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private const string ApiUri = "https://localhost:7170/api/v1/Annonce";

        public AnnonceService(HttpClient httpClient,IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task CreateAnnonce(AddAnnonceDto annonceDto)
        {
            var result=await _httpClient.PostAsJsonAsync<AddAnnonceDto>(ApiUri, annonceDto);
            if (result.IsSuccessStatusCode)
            {

                _toastService.ShowSuccess("the data has successfully been updated");
            }
            else
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task DeleteAnnonce(string annonceId)
        {
            var result=await _httpClient.DeleteAsync($"{ApiUri}/{annonceId}");
            if (result.IsSuccessStatusCode)
            {

                _toastService.ShowSuccess("the data has successfully been updated");
            }
            else
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task<Pagination<AnnonceDto>?> GetAll(int page)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Pagination<AnnonceDto>>(ApiUri+$"/page/{page}");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AnnonceDto?> GetAnnonceById(string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<AnnonceDto?>($"{ApiUri}/{id}");

            }
            catch (Exception)
            {
                return new AnnonceDto();
            }
        }

        public async Task UpdateAnnonce(string id, UpdateAnnonceDto annonceDto)
        {
            
            var result =await _httpClient.PutAsJsonAsync<UpdateAnnonceDto>($"{ApiUri}/{id}", annonceDto);
            if(result.IsSuccessStatusCode)
            {
                
                _toastService.ShowSuccess("the data has successfully been updated");
            }
           else
           {

                _toastService.ShowError("an error has occured");
           }
        }


    }
}
