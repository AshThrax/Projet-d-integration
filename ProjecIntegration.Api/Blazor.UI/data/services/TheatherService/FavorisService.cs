using Blazor.UI.Data.ModelViews.Theater;
using Blazor.UI.Data.ServiceResult;
using Blazored.Toast.Services;
using Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.TheatherService
{
    public interface IFavorisService
    { 
        Task<ServiceResponse<FavorisDto>> AddPiece(int  pieceId);
        Task Create();
        Task Update(int FavorisDto,FavorisDto favorisDto);
        Task DeletePiece(int pieceId);
        Task<Pagination<PieceDto>> GetFavoris(int page);
        
    }
    public class FavorisService : IFavorisService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly string ApiUri= "https://localhost:7170/api/v1/Favoris";

        public FavorisService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;

        }

        public async Task<ServiceResponse<FavorisDto>> AddPiece(int pieceId)
        {
            ServiceResponse<FavorisDto> response = new();
            try
            {
                var httpmess= await _httpClient.PostAsync(ApiUri+$"/addfavoris/{pieceId}",null);
                try
                {
                  httpmess.EnsureSuccessStatusCode();
                    _toastService.ShowSuccess("success fully added to the favorite");
                }
                catch (Exception)
                {

                    _toastService.ShowError("an error has occured");
                }
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

        public async Task DeletePiece( int pieceId)
        {
           
            try
            {
                var httpmes=await _httpClient.DeleteAsync(ApiUri+$"/deletefavoris/{pieceId}");
                try
                {
                    httpmes.EnsureSuccessStatusCode();
                    _toastService.ShowSuccess("the data has been remove from favorite");
                }
                catch (Exception)
                {

                    _toastService.ShowError("an error has occured");
                }
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
              var result= await _httpClient.PutAsJsonAsync<FavorisDto>(ApiUri,favorisDto);
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
            catch (Exception)
            {
               
            }
        }
    }
}
