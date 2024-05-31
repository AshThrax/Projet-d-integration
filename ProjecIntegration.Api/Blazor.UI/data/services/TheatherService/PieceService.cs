using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Blazor.UI.Client.manager;
using Blazor.UI.Data.modelViews.Theater;
using Newtonsoft.Json;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface IPieceService
    {
        Task<IEnumerable<PieceDto>> Get();
        Task<PieceDto> GetById(int id);
        Task<IEnumerable<PieceDto>> GetByComplexe(int id);
        Task<IEnumerable<PieceDto>> GetByCatalogue(int id);
        Task<IEnumerable<PieceDto>> GetByTheme(int id);
        Task Create(AddPieceDto data);
        Task AddRepresentation(int pieceId, AddRepresentationDto data);
        Task AddToCatalogue(int catalogueId, int pieceId);
        Task RemovefromCatalogue(int catalogueId, int pieceId);
        Task Update(int id, UpdatePieceDto data);
        Task Delete(PieceDto data);
        Task DeleteRepresentation(int idPiece, int idRepresentation);
    }

    public class PieceService : IPieceService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/v1/Piece";

        public PieceService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<IEnumerable<PieceDto?>?> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto?>?>(ApiUri);
        }

        public async Task<PieceDto?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<PieceDto?>($"{ApiUri}/{id}");
        }

        public async Task<IEnumerable<PieceDto?>?> GetByComplexe(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto?>?>($"{ApiUri}/get-complexe/{id}");
        }

        public async Task Create(AddPieceDto piecedata)
        {
            var data = JsonConvert.SerializeObject(piecedata);
            var sendData = new StringContent(data, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(ApiUri, sendData);
        }

        public async Task AddRepresentation(int idPiece, AddRepresentationDto data)
        {
            await _httpClient.PostAsJsonAsync($"{ApiUri}/add-representation/{idPiece}", data);
        }

        public async Task Update(int id, UpdatePieceDto data)
        {
            await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
        }

        public async Task Delete(PieceDto data)
        {
            await _httpClient.DeleteAsync(ApiUri);
        }

        public async Task DeleteRepresentation(int idPiece, int idRepresentation)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/delete-representation/{idPiece}/{idRepresentation}");
        }

        public async Task<IEnumerable<PieceDto>?> GetByCatalogue(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto>>($"{ApiUri}/catalogue/{id}");
        }
        public async  Task<IEnumerable<PieceDto>?> GetByTheme(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto>>($"{ApiUri}/theme/{id}");
        }

        public async Task AddToCatalogue(int catalogueId, int pieceId)
        {
            await _httpClient.GetAsync($"{ApiUri}/add-catalogue/{catalogueId}/{pieceId}");
        }

        public async Task RemovefromCatalogue(int catalogueId, int pieceId)
        {
            await _httpClient.GetAsync($"{ApiUri}/remove-catalogue/{catalogueId}/{pieceId}");
        }
    }
}