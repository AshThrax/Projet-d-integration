using Blazor.UI.Data.ModelViews.Theater;
using Blazored.Toast.Services;
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
        private readonly IToastService _toastService;
        public ThemeService(HttpClient httpClient,IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<IEnumerable<ThemeDto>?> GetAllTheme()
        {
            ServiceResponse<IEnumerable<ThemeDto>>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<ThemeDto>>?>(ApiUri);
            if (response.Success)
            {
                _toastService.ShowSuccess("");
                return response.Data;
            }
            else
            {
                _toastService.ShowSuccess("an error has occured");
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
