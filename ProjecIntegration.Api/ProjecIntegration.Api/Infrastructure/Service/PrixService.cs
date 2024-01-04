using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class PrixService : GeneriqueService<Prix, PrixDto>, IPrixService
    {
        public PrixService(IRepository<Prix> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
