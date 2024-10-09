using Blazor.UI.Data.ModelViews.Publication;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using Stripe;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.User
{
    public interface IUserService
    {
        Task<UserDto> GetUserProfile(string userId);
        Task<Pagination<UserDto>> GetListUser(List<string> userId);
        Task<IEnumerable<UserDto>> GetAllUser();
        Task DeleteUser(string userId);
        Task UnBlockuser (string userId);
        Task BlockUser(string userId);
        Task nominateAdmin(string userId);
        Task UnnominateasAdmin(string userId);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUri = "https://localhost:7170/api/v1/User";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task BlockUser(string userId)
        {
            await _httpClient.DeleteAsync(ApiUri + $"/block/{userId}");
        }

        public async Task DeleteUser(string userId)
        {
            await _httpClient.DeleteAsync(ApiUri + $"/{userId}");
        }

        public async Task<IEnumerable<UserDto>> GetAllUser()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>(ApiUri);
        }

        public async Task<UserDto> GetUserProfile(string userId)
        {
            ServiceResponse<UserDto>? reponse = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>(ApiUri + $"/{userId}");
            if (reponse.Success)
            {
                return reponse.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task UnBlockuser(string userId)
        {
            await _httpClient.PostAsJsonAsync<string>(ApiUri + $"/unblock/{userId}", "");
        }
        public async Task nominateAdmin(string userId)
        {
            await _httpClient.PostAsJsonAsync<string>(ApiUri + $"nom-admin/{userId}", "");
        }

        public async Task<Pagination<UserDto>> GetListUser(List<string> userId)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<UserDto>>(ApiUri+"/fromlist");
        }
        public async Task UnnominateasAdmin(string userId)
        {
            await _httpClient.PutAsJsonAsync<string>(ApiUri + $"/unnom-admin/{userId}","");
        }
    }
}
