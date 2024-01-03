using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class ComplexeRepository : Repository<Complexe>, IComplexeRepository
    {
        public ComplexeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
