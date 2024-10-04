
using Blazor.UI.Data.ModelViews.Publication;
using Blazor.UI.Data.ServiceResult;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.Publication
{
    public interface IPublicationService
    {
        Task AddPublication(AddPublicationDto catalogueDto);
        Task DeletePublication(string Id);
        Task<PublicationDto> GetPublication(string Id);
        Task<PublicationDto> UpdatePublication(string Id, PublicationDto catalogue);
        Task<Pagination<PublicationDto>> GetPublicationByUserId(int page);
        Task<Pagination<PublicationDto>> GetOtherPublicationByUserId(string userId,int page);
        Task<Pagination<PublicationDto>> GetAllPublicationByPieceId(int page,int id);

        //--------------------------------------------------

    }
    public class PublicationService : IPublicationService
    {

        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:7170/api/v1/Publication";

        public PublicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddPublication(AddPublicationDto catalogueDto)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, catalogueDto);
        }

        public async Task DeletePublication(string Id)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{Id}");
        }

        public async Task<PublicationDto?> GetPublication(string Id)
        {
            return await _httpClient.GetFromJsonAsync<PublicationDto>($"{ApiUri}/publication-by-id/{Id}");
        }

        public Task<PublicationDto> UpdatePublication(string Id, PublicationDto catalogue)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<PublicationDto>?> GetPublicationByUserId(int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PublicationDto>?>($"{ApiUri}/publication-by-user/{page}");
        }

        public async Task<Pagination<PublicationDto>?> GetAllPublicationByPieceId(int page,int id)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PublicationDto>?>($"{ApiUri}/by-piece/{page}/{id}");
        }

        public async Task<Pagination<PublicationDto>?> GetOtherPublicationByUserId(string userId, int page)
        {
            return await _httpClient.GetFromJsonAsync<Pagination<PublicationDto>?>($"{ApiUri}/publication-by-user//{userId}/{page}");
        }
    }
}
