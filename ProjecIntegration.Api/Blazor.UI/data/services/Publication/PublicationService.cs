
using Blazor.UI.Data.ModelViews.Publication;
using Blazor.UI.Data.ServiceResult;
using Data.ServiceResult;
using System;
using System.Net.Http.Json;

namespace Blazor.UI.Data.services.Publication
{
    public interface IPublicationService
    {
        Task AddPublication(AddPublicationDto catalogueDto);
        Task DeletePublication(string Id);
        Task<PublicationDto> GetPublication(string Id);
        Task UpdatePublication(string Id, UpdatePublicationDto catalogue);
        Task<Pagination<PublicationDto>> GetPublicationByUserId(int page);
        Task<Pagination<PublicationDto>> GetOtherPublicationByUserId(string userId,int page);
        Task<Pagination<PublicationDto>> GetAllPublicationByPieceId(int page,int id);
        Task<bool> IsAuthor(string pubId);
        Task<bool> Hasreview(int pieceId);

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
            await _httpClient.PostAsJsonAsync<AddPublicationDto>(ApiUri+ "/create-publication", catalogueDto);
        }

        public async Task DeletePublication(string Id)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/{Id}");
        }

        public async Task<PublicationDto?> GetPublication(string Id)
        {
            var result= await _httpClient.GetFromJsonAsync<ServiceResponse<PublicationDto>>($"{ApiUri}/publication-by-id/{Id}");
            return result.Data;
        }

        public async Task UpdatePublication(string Id,UpdatePublicationDto catalogue)
        {
           await _httpClient.PutAsJsonAsync<UpdatePublicationDto>($"{ApiUri}/update-publication/{Id}",catalogue);
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

        public async Task<bool> IsAuthor(string pubId)
        {
            return await _httpClient.GetFromJsonAsync<bool>(ApiUri + $"/iswriter/{pubId}");
        }

        public async Task<bool> Hasreview(int pieceId)
        {
            return await _httpClient.GetFromJsonAsync<bool>(ApiUri + $"/hasreview/{pieceId}");
        
        }
    }
}
