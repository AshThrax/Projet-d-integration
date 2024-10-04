using Blazor.UI.Data.ModelViews.User;
using Data.ServiceResult;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Blazor.UI.Data.Services.User
{
    public interface IBannerService
    {
        Task<BannerDto> Getbanner();
        Task<BannerDto> Getbanner(string userId);
        Task  Createbanner(MultipartFormDataContent addContent);
        Task ChangeBanner(MultipartFormDataContent uploadContent);
    }
    public class BannerService : IBannerService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiBaseUrl = "https://localhost:7170/api/v1/Banner";

        public BannerService(HttpClient httpClient)
        {
            this._httpClient = httpClient;

        }

        public async Task ChangeBanner(MultipartFormDataContent uploadContent)
        {
            try
            {
                var response = await _httpClient.PostAsync(apiBaseUrl, uploadContent);
                if (response.IsSuccessStatusCode)
                {
                    var ImgContent = await response.Content.ReadAsStringAsync();
                    BannerDto banner = JsonConvert.DeserializeObject<BannerDto>(ImgContent);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Createbanner(MultipartFormDataContent addContent)
        {
            try
            {
                var response = await _httpClient.PostAsync(apiBaseUrl, addContent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BannerDto> Getbanner()
        {
            ServiceResponse<BannerDto> response = new();
            try
            {
                response =await _httpClient.GetFromJsonAsync<ServiceResponse<BannerDto>>(apiBaseUrl);
               
                return response.Data;
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<BannerDto> Getbanner(string userId)
        {
            ServiceResponse<BannerDto>? response = new();
            try
            {
                response = await _httpClient.GetFromJsonAsync<ServiceResponse<BannerDto>>(apiBaseUrl+$"/{userId}");
                if (response.Success)
                {
                  return response.Data;
                }
                else
                {
                    return new BannerDto(); 
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
