using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class CatalogueService : GeneriqueService<Catalogue, CatalogueDto>, ICatalogueService
    {
        public CatalogueService(IRepository<Catalogue> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
