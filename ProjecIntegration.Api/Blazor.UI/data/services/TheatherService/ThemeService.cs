using Blazor.UI.data.modelViews;
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
        private const string ApiUri = "https://localhost:44337/api/v1/Theatre";

        public ThemeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ThemeDto>> GetAllTheme()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ThemeDto>>(ApiUri);
        }
        public async Task<ThemeDto> GetThemeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ThemeDto>($"{ApiUri}/{id}");
        }
    }
    
}
