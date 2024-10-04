using Blazor.UI.Data.ModelViews.User;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.User
{
    public interface IFollowService
    {
        Task AddFollow(string userId);
        Task DeleteFollow(string userId);
        Task<Pagination<FollowDto>> GetFollower(string userId);
        Task<Pagination<FollowDto>> GetFollowed(string userId);
        Task<int> GetFollowerNumber(string userId);
        Task<bool> DoIFollow(string userId);
    }
    public class FollowService : IFollowService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUri = "https://localhost:7170/api/v1/Follow";

        public FollowService(HttpClient httpClient, string apiUri)
        {
            _httpClient = httpClient;
            ApiUri = apiUri;
        }

        public async Task AddFollow(string userId)
        {
            try
            {
                await _httpClient.PostAsJsonAsync(ApiUri, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteFollow(string userId)
        {
            try
            {
                await _httpClient.DeleteAsync(ApiUri+$"/{userId}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Pagination<FollowDto>> GetFollower(string userId)
        {
            Pagination<FollowDto> response;
            try
            {
                response = await _httpClient.GetFromJsonAsync<Pagination<FollowDto>>(ApiUri + $"/follower");
                return response;
            
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Pagination<FollowDto>> GetFollowed(string userId)
        {
            Pagination<FollowDto> response;
            try
            {
                response = await _httpClient.GetFromJsonAsync<Pagination<FollowDto>>(ApiUri + $"/followed");
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetFollowerNumber(string userId)
        {
            ServiceResponse<int>? response = new ServiceResponse<int>();
            try
            {
               response =  await _httpClient.GetFromJsonAsync<ServiceResponse<int>>(ApiUri+$"/{userId}");
                return response.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> DoIFollow(string userId)
        {
            ServiceResponse<bool>? response = new ServiceResponse<bool>();
            try
            {
                response = await _httpClient.GetFromJsonAsync<ServiceResponse<bool>>(ApiUri+"do-i-follow");
                return response.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
