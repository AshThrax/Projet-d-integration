using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.TheatherService
{
    public interface IFavorisService
    { 
        Task<ServiceResponse<FavorisDto>> AddPiece(int  pieceId);
        Task Create();
        Task Update(int FavorisDto,FavorisDto favorisDto);
        Task DeletePiece(int favorisId,int pieceId);
        Task<Pagination<PieceDto>> GetFavoris(int page);
        
    }
    public class FavorisService : IFavorisService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUri= "https://localhost:7170/api/v1/Favoris";

        public FavorisService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ServiceResponse<FavorisDto>> AddPiece(int pieceId)
        {
            ServiceResponse<FavorisDto> response = new();
            try
            {
                var httpmess= await _httpClient.PostAsync(ApiUri+$"/addFavoris/{pieceId}",null);
                return response;
            }
            catch (Exception)
            {
                response.Errortype=Errortype.Bad;
                response.Success=false;
                response.Message = "une erreur a eu lieu";
                throw;
            }
        }

        public async Task Create()
        {
            ServiceResponse<FavorisDto> response = new();
            try
            {
                HttpResponseMessage http = await _httpClient.PostAsJsonAsync<FavorisDto>(ApiUri, null);
                http.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {
                response.Errortype = Errortype.Bad;
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                throw;
            }
        }

        public async Task DeletePiece(int favorisId, int pieceId)
        {
           
            try
            {
                await _httpClient.DeleteFromJsonAsync<ServiceResponse<FavorisDto>>(ApiUri);
               
            }
            catch (Exception)
            {

            }
        }

        public async Task<Pagination<PieceDto>> GetFavoris(int page)
        {

            try
            {
               Pagination<PieceDto> getfavoris= await _httpClient.GetFromJsonAsync<Pagination<PieceDto>>(ApiUri+$"/{page}");
                return getfavoris;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(int FavorisDto, FavorisDto favorisDto)
        {
           
            try
            {
                await _httpClient.PutAsJsonAsync<FavorisDto>(ApiUri,favorisDto);
              

            }
            catch (Exception)
            {
               
            }
        }
    }
}
