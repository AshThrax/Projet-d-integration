using Microsoft.EntityFrameworkCore;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class CatalogueRepository : Repository<Catalogue>, ICatalogueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CatalogueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRepresentation(int catalogueid, Representation representation)
        {
           var Catalogue= _dbContext.Catalogues.Include(x =>x.Representations)
                .FirstOrDefault(c =>c.Id == catalogueid);

            if (representation != null)
            {
                Catalogue.Representations.Add(representation);
                _dbContext.SaveChanges();   

            }
        }

        public void DeleteRepresentation(int catalogueid, int represenatationid)
        {
            var Catalogue = _dbContext.Catalogues.Include(x => x.Representations)
               .FirstOrDefault(c => c.Id == catalogueid);

        var representationRemove = _dbContext.Representations.FirstOrDefault(x=> x.Id == represenatationid);
            if (representationRemove != null)
            {
                Catalogue.Representations.Add(representationRemove);
                _dbContext.SaveChanges();

            }
        }
    }
}
