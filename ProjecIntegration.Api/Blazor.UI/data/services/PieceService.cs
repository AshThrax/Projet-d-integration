using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.UI.Client.manager;
using Blazor.UI.data.modelViews;

namespace Blazor.UI.data.services
{
    public interface IPieceService
    {
        Task<IEnumerable<PieceDto>> Get();
        Task<PieceDto> GetById(int id);
        Task<IEnumerable<PieceDto>> GetByComplexe(int id);
        Task Create(AddPieceDto data);
        Task AddRepresentation(int idPiece, AddRepresentationDto data);
        Task Update(int id, UpdatePieceDto data);
        Task Delete(PieceDto data);
        Task DeleteRepresentation(int idPiece, int idRepresentation);
    }

    public class PieceService : IPieceService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/Piece";

        public PieceService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<IEnumerable<PieceDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto>>(ApiUri);
        }

        public async Task<PieceDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<PieceDto>($"{ApiUri}/{id}");
        }

        public async Task<IEnumerable<PieceDto>> GetByComplexe(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto>>($"{ApiUri}/get-complexe/{id}");
        }

        public async Task Create(AddPieceDto data)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, data);
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
    }
}