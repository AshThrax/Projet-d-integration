using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class SalleDeTheatreService : GeneriqueService<SalleDeTheatre, SalleDeTheatreDto>,
        ISalleDeTheatreSevice
    {
        public SalleDeTheatreService(IRepository<SalleDeTheatre> repository, IMapper mapper) : 
            base(repository, mapper)
        {
        }
    }
}
