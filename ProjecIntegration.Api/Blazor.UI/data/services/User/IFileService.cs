using Blazor.UI.Data.ModelViews.Theater;
using Newtonsoft.Json;

namespace Blazor.UI.Data.Services.User
{
    public interface IFileService
    {
        Task SendImage(MultipartFormDataContent Content);
    }
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUri = "";

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task SendImage(MultipartFormDataContent Content)
        {
            var response = await _httpClient.PostAsync("/api/File", Content);
            if (response.IsSuccessStatusCode)
            {
                var ImgContent = await response.Content.ReadAsStringAsync();
                ImageDto banner = JsonConvert.DeserializeObject<ImageDto>(ImgContent);

            }
        }
    }
}
