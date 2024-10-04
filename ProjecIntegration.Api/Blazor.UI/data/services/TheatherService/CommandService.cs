using System.Net.Http.Json;
using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
namespace Blazor.UI.Data.services.TheatherService
{
    public interface ICommandService
    {
        Task<CommandDto[]?> Get();
        Task<string> GetAuth();
        Task<CommandDto> GetById(int id);
        Task<Pagination<CommandDto>> GetByUser(int page);
        Task<CommandDto[]?> GetByPiece(int idPiece);
        Task Create(AddCommandDto data);
        Task Update(int id, UpdateCommandDto data);
        Task Delete(int id);
        Task<bool> DoIHaveacommand(int Id);
    }
    public class CommandService :
     ICommandService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Command";

        public CommandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommandDto[]?> Get()
        {
            return await _httpClient.GetFromJsonAsync<CommandDto[]>(ApiUri);
        }

        public async Task<string?> GetAuth()
        {
            return await _httpClient.GetFromJsonAsync<string>($"{ApiUri}/get-auth");
        }

        public async Task<CommandDto?> GetById(int id)
        {
            ServiceResponse<CommandDto>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<CommandDto>>($"{ApiUri}/{id}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<Pagination<CommandDto>?> GetByUser(int page)
        {
            try
            {

                return await _httpClient.GetFromJsonAsync<Pagination<CommandDto>>($"{ApiUri}/get-command-user/{page}");
            }
            catch (Exception)
            {
                return new Pagination<CommandDto>(new List<CommandDto>(), 1, 1); 
            }
        }

        public async Task<CommandDto[]?> GetByPiece(int idPiece)
        {
            ServiceResponse<CommandDto[]>? response= await _httpClient.GetFromJsonAsync<  ServiceResponse<CommandDto[]>?>($"{ApiUri}/get-piece/{idPiece}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
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

        public async Task<bool> DoIHaveacommand(int Id)
        {
             return await _httpClient.GetFromJsonAsync<bool>($"{ApiUri}/exist/{Id}");
        }
    }
}