
using Blazor.UI.modelViews;
using Blazor.UI.services;
using System.Net.Http.Json;
using Microsoft.Extensions.Http;
namespace Blazor.UI.services
{
    public interface ICommandService 
    {
        Task<CommandDto[]> Get();
        Task<string> GetAuth();
        Task<CommandDto> GetById(int id);
        Task<CommandDto[]> GetByUser();
        Task<CommandDto[]> GetByPiece(int idPiece);
        Task Create(AddCommandDto data);
        Task Update(int id, UpdateCommandDto data);
        Task Delete(int id);
    }
    public class CommandService :
     ICommandService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/Command";

        public CommandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommandDto[]> Get()
        {
            return await _httpClient.GetFromJsonAsync<CommandDto[]>(ApiUri);
        }

        public async Task<string> GetAuth()
        {
            return await _httpClient.GetFromJsonAsync<string>($"{ApiUri}/get-auth");
        }

        public async Task<CommandDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<CommandDto>($"{ApiUri}/{id}");
        }

        public async Task<CommandDto[]> GetByUser()
        {
            return await _httpClient.GetFromJsonAsync<CommandDto[]>($"{ApiUri}/get-command-user/");
        }

        public async Task<CommandDto[]> GetByPiece(int idPiece)
        {
            return await _httpClient.GetFromJsonAsync<CommandDto[]>($"{ApiUri}/get-piece/{idPiece}");
        }

        public async Task Create(AddCommandDto data)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, data);
        }

        public async Task Update(int id, UpdateCommandDto data)
        {
            await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{id}");
        }
    }
}