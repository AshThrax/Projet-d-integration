using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class ComplexeService : GeneriqueService<Complexe, ComplexeDto>, IComplexeService
    {
        public ComplexeService(IRepository<Complexe> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
