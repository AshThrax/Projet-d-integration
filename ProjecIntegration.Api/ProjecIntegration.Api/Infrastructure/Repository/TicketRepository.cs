using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Ticket> GetAllbyCommandId(int CommandId)
        {
            throw new NotImplementedException();
        }

        public Ticket GetByCommandId(int CommandId, int ticketid)
        {
            throw new NotImplementedException();
        }
    }
}
