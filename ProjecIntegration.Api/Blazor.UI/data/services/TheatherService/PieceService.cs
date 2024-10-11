using System.Net.Http.Json;
using System.Text;
using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Blazored.Toast.Services;
using Data.ServiceResult;
using Newtonsoft.Json;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface IPieceService
    {
        Task<Pagination<PieceDto>> Get(int page);
        Task<IEnumerable<PieceDto>> Getlist();
        Task<PieceDto> GetById(int id);
        Task<Pagination<PieceDto>> GetByComplexe(int id,int page);
        Task<Pagination<PieceDto>> GetByCatalogue(int id,int page);
        Task<Pagination<PieceDto>> GetByTheme(int id,int page);
        Task Create(AddPieceDto data);
        Task AddRepresentation(int pieceId, AddRepresentationDto data);
        Task AddToCatalogue(int catalogueId, int pieceId);
        Task RemovefromCatalogue(int catalogueId, int pieceId);
        Task Update(int id, UpdatePieceDto data);
        Task Delete(int Id);
        Task DeleteRepresentation(int idPiece, int idRepresentation);
    }

    public class PieceService : IPieceService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private const string ApiUri = "https://localhost:7170/api/v1/Piece";

        public PieceService(HttpClient httpClient, IToastService toastService)
        {

            _httpClient = httpClient;
            _toastService = toastService;

        }

        public async Task<Pagination<PieceDto?>?> Get(int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PieceDto?>?>($"{ApiUri}/{page}");
        }
        public async Task<IEnumerable<PieceDto?>?> Getlist()
        {
            ServiceResponse <IEnumerable<PieceDto>>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<PieceDto>>?>($"{ApiUri}/list");

            if (response.Success)
            {
                return response.Data;
            }
            else { 
                return null;
            }
        }
        public async Task<PieceDto?> GetById(int id)
        {
            ServiceResponse<PieceDto>? response= await _httpClient.GetFromJsonAsync<ServiceResponse<PieceDto>?>($"{ApiUri}/single/{id}");

            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<Pagination<PieceDto?>?> GetByComplexe(int id,int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PieceDto?>?>($"{ApiUri}/get-complexe/{id}/{page}");
        }

        public async Task Create(AddPieceDto piecedata)
        {
            var data = JsonConvert.SerializeObject(piecedata);
            var sendData = new StringContent(data, Encoding.UTF8, "application/json");
            var result =await _httpClient.PostAsync(ApiUri, sendData);
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been added");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task AddRepresentation(int idPiece, AddRepresentationDto data)
        {
            var result =await _httpClient.PostAsJsonAsync($"{ApiUri}/add-representation/{idPiece}", data);
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been added");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task Update(int id, UpdatePieceDto data)
        {
            var result=await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
            try
            {
                result.EnsureSuccessStatusCode();
               _toastService.ShowSuccess("the data has successfully been updated");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task Delete(int Id)
        {
            var result=await _httpClient.DeleteAsync(ApiUri+$"/{Id}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been deleted");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task DeleteRepresentation(int idPiece, int idRepresentation)
        {
            var result=await _httpClient.DeleteAsync($"{ApiUri}/delete-representation/{idPiece}/{idRepresentation}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the representation has successfully been added to this piece");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task<Pagination<PieceDto>?> GetByCatalogue(int id, int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PieceDto>>($"{ApiUri}/catalogue/{id}/{page}");
        }
        public async  Task<Pagination<PieceDto>?> GetByTheme(int id,int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PieceDto>>($"{ApiUri}/theme/{id}/{page}");
        }

        public async Task AddToCatalogue(int catalogueId, int pieceId)
        {
            var result =await _httpClient.GetAsync($"{ApiUri}/add-catalogue/{catalogueId}/{pieceId}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been added to the catalogue");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }

        public async Task RemovefromCatalogue(int catalogueId, int pieceId)
        {
            var result =await _httpClient.GetAsync($"{ApiUri}/remove-catalogue/{catalogueId}/{pieceId}");
            try
            {
                result.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("the data has successfully been removed");
            }
            catch (Exception)
            {

                _toastService.ShowError("an error has occured");
            }
        }
    }
}