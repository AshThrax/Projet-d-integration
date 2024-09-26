using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfraTheather.Infrastructure.Repository
{
    public class CatalogueRepository : Repository<Catalogue>, ICatalogueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CatalogueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Catalogue>> GetCatalogueFromComplexe(int complexeId)
        {
            try
            {
                return await _dbContext.Catalogue.Where(x=>x.ComplexeId == complexeId).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
