using Blazor.UI.Data.ModelViews.Theater;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.data.services.TheatherService
{
    public interface IThemeService
    {
        Task<IEnumerable<ThemeDto>> GetAllTheme();
        Task<ThemeDto> GetThemeById(int id);
    }
    public class ThemeService: IThemeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Theatre";

        public ThemeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ThemeDto>?> GetAllTheme()
        {
            ServiceResponse<IEnumerable<ThemeDto>>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<ThemeDto>>?>(ApiUri);
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
        public async Task<ThemeDto?> GetThemeById(int id)
        {
            ServiceResponse<ThemeDto>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<ThemeDto>?>($"{ApiUri}/{id}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
    }
    
}
