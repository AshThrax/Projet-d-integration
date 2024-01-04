using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class TicketService : GeneriqueService<Ticket, TicketsDto>, ITicketService
    {
        public TicketService(IRepository<Ticket> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
