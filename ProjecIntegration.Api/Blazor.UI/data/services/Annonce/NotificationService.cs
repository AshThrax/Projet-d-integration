
using Blazor.UI.Data.modelViews.Annonce;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.Annonce;

public interface INotificaitonService
{
    Task<IEnumerable<NotificationDto>> GetAll();

}
public class NotificationService : INotificaitonService
{
    private readonly HttpClient _httpClient;
    private const string ApiUri = "https://localhost:7170/api/v1/notification";

    public NotificationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }



    public async Task<IEnumerable<NotificationDto>?> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<NotificationDto[]?>(ApiUri);
    }


}