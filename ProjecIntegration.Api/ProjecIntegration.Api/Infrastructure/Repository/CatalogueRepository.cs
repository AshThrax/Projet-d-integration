using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class CatalogueRepository : Repository<Catalogue>, ICatalogueRepository
    {
        public CatalogueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
