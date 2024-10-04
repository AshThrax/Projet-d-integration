using Blazor.UI.Data.ModelViews.User;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using Microsoft.AspNetCore.Http;
using Stripe;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.User
{
    public interface IFeedBackService
    { 
        Task AddFeedBack(AddFeedBackDto feedBackDto);
        Task<Pagination<FeedBackDto >> GetAll(int page);
        Task<FeedBackDto> GetbyId(int feedBackId);
        Task<FeedBackDto> GetbyUser();

    }
    public class FeedBackService : IFeedBackService
    {
        private readonly HttpClient _httpClient;
        private readonly string _ApiUri = "https://localhost:7170/api/v1/FeedBack";

        public FeedBackService(HttpClient httpClient, string apiUri)
        {
            this._httpClient = httpClient;
            _ApiUri = apiUri;
        }

        public async Task AddFeedBack(AddFeedBackDto feedBackDto)
        {
            ServiceResponse<FeedBackDto> response = new();
            try
            {
                await _httpClient.PostAsJsonAsync(_ApiUri, feedBackDto);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Pagination<FeedBackDto>> GetAll(int page)
        {
            ServiceResponse<Pagination<FeedBackDto>> response = new();
            try
            {
                response = await _httpClient.GetFromJsonAsync<ServiceResponse<Pagination<FeedBackDto>>>(_ApiUri) 
                                            ?? throw new TimeoutException(); ;

                return response.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FeedBackDto> GetbyId(int feedBackId)
        {
            ServiceResponse<FeedBackDto> response = new();
            try
            {
                response = await _httpClient.GetFromJsonAsync<ServiceResponse<FeedBackDto>>(_ApiUri+$"/{feedBackId}") 
                                            ?? throw new TimeoutException(); ;

                return response.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FeedBackDto> GetbyUser()
        {
            ServiceResponse<FeedBackDto> response = new();
            try
            {
                response = await _httpClient.GetFromJsonAsync<ServiceResponse<FeedBackDto>>(_ApiUri + "/byuser") 
                                            ?? throw new TimeoutException(); 
                return response.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
