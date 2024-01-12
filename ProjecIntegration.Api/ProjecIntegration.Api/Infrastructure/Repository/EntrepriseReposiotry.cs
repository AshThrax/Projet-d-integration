using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class EntrepriseReposiotry : Repository<Entreprise>, IEntrepriseRepository
    {
        public EntrepriseReposiotry(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
