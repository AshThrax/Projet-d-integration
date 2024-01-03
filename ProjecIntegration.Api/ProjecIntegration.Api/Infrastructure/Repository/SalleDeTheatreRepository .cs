using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class SalleDeTheatreRepository : Repository<SalleDeTheatre>, ISalleDeTheatreRepository
    {
        public SalleDeTheatreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
