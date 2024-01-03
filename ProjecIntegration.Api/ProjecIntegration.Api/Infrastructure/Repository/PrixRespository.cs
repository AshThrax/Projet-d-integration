using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class PrixRespository : Repository<Prix>, IPrixRepository
    {
        public PrixRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
