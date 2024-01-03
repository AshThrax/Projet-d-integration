using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class RepresentationRespository : Repository<Representation>, IRepresentationRepository
    {
        public RepresentationRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
