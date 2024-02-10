using Blazor.UI.modelViews;
using System.Net.Http.Json;

namespace Blazor.UI.services
{
    public interface IRepresentationService
    {

        Task<IEnumerable<RepresentationDto>> Get();
        Task<RepresentationDto> GetById(int id);
        Task Create(AddRepresentationDto data);
        Task Update(UpdateRepresentationDto data);
        Task Delete(int id);
        Task<IEnumerable<RepresentationDto>> GetSalle(int idSalle);
        Task<IEnumerable<RepresentationDto>> GetPiece(int idPiece);
        Task AddCommandRepresentation(int id, AddCommandDto data);
        Task DeleteCommandRepresentation(int idRep, int idCommand);
    }
   
        public class RepresentationService : IRepresentationService
        {
            private readonly HttpClient _httpClient;
            private const string ApiUri = "https://localhost:44337/api/Representation";

            public RepresentationService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<IEnumerable<RepresentationDto>> Get()
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<RepresentationDto>>(ApiUri);
            }

            public async Task<RepresentationDto> GetById(int id)
            {
                return await _httpClient.GetFromJsonAsync<RepresentationDto>($"{ApiUri}/{id}");
            }

            public async Task Create(AddRepresentationDto data)
            {
                await _httpClient.PostAsJsonAsync(ApiUri, data);
            }

            public async Task Update(UpdateRepresentationDto data)
            {
                await _httpClient.PutAsJsonAsync(ApiUri, data);
            }

            public async Task Delete(int id)
            {
                await _httpClient.DeleteAsync($"{ApiUri}/{id}");
            }

            public async Task<IEnumerable<RepresentationDto>> GetSalle(int idSalle)
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<RepresentationDto>>($"{ApiUri}/get-salle/{idSalle}");
            }

            public async Task<IEnumerable<RepresentationDto>> GetPiece(int idPiece)
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<RepresentationDto>>($"{ApiUri}/get-piece/{idPiece}");
            }

            public async Task AddCommandRepresentation(int id, AddCommandDto data)
            {
                await _httpClient.PostAsJsonAsync($"https://localhost:44337/api/Representation/add-command/{id}", data);
            }

            public async Task DeleteCommandRepresentation(int idRep, int idCommand)
            {
                await _httpClient.DeleteAsync($"{ApiUri}/delete-command/{idRep}/{idCommand}");
            }
        } 
 }
