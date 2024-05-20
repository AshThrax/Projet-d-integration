using Blazor.UI.Data.modelViews.Theater;

namespace Blazor.UI.Data.services.TheatherService
{
    public interface ICatalogueService
    {
        Task AddCatalogue(CatalogueDto catalogueDto);
        Task DeleteCatalogue(int catalogueId);
        Task<CatalogueDto> GetCatalogue(int catalogueId);
        Task<CatalogueDto> UpdateCatalogue(int catalogueId, CatalogueDto catalogue);
        Task<CatalogueDto> GetCatalogue();
        Task<IEnumerable<CatalogueDto>> GetAllCatalogue();
        Task<IEnumerable<CatalogueDto>> GetAllCatalogueByComplexeId(int complexeId);
    }
    public class CataloguesService : ICatalogueService
    {

        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/v1/Catalogue";

        public CataloguesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddCatalogue(CatalogueDto catalogueDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCatalogue(int catalogueId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogueDto>> GetAllCatalogue()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogueDto>> GetAllCatalogueByComplexeId(int complexeId)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogueDto> GetCatalogue(int catalogueId)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogueDto> GetCatalogue()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogueDto> UpdateCatalogue(int catalogueId, CatalogueDto catalogue)
        {
            throw new NotImplementedException();
        }
    }
}
