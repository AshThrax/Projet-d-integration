using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class RepresentationService : GeneriqueService<Representation, RepresentationDto>, 
        IRepresentationService
    {
        public RepresentationService(IRepository<Representation> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
