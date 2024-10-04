
using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface IRepresentationService
    {

        Task<Pagination<RepresentationDto>> Get(int page);
        Task<RepresentationDto> GetById(int id);
        Task Create(AddRepresentationDto data);
        Task Update(UpdateRepresentationDto data);
        Task Delete(int id);
        Task<Pagination<RepresentationDto>> GetSalle(int idSalle,int page);
        Task<Pagination<RepresentationDto>> GetPiece(int idPiece,int page);
        Task AddCommandRepresentation(int id, int idPlace, AddCommandDto data);
        Task DeleteCommandRepresentation(int idRep, int idCommand);
    }

    public class RepresentationService : IRepresentationService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Representation";

        public RepresentationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pagination<RepresentationDto>?> Get(int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<RepresentationDto>>($"{ApiUri}/{page}");
        }

        public async Task<RepresentationDto?> GetById(int id)
        {
            ServiceResponse<RepresentationDto>? response = await _httpClient.GetFromJsonAsync<ServiceResponse<RepresentationDto>?>($"{ApiUri}/{id}");
            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task Create(AddRepresentationDto data)
        {
            await _httpClient.PostAsJsonAsync<AddRepresentationDto>(ApiUri, data);
        }

        public async Task Update(UpdateRepresentationDto data)
        {
            await _httpClient.PutAsJsonAsync<UpdateRepresentationDto>(ApiUri+$"/{data.Id}", data);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{id}");
        }

        public async Task<Pagination<RepresentationDto>?> GetSalle(int idSalle,int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<RepresentationDto>?>($"{ApiUri}/from-salle/{idSalle}/{page}");
        }

        public async Task<Pagination<RepresentationDto>?> GetPiece(int idPiece,int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<RepresentationDto>>($"{ApiUri}/from-piece/{idPiece}/{page}");
        }

        public async Task AddCommandRepresentation(int id, int idplace, AddCommandDto data)
        {
            await _httpClient.PostAsJsonAsync($"https://localhost:44337/api/Representation/add-command/{id}/{idplace}", data);
        }

        public async Task DeleteCommandRepresentation(int idRep, int idCommand)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/delete-command/{idRep}/{idCommand}");
        }
    }
}
