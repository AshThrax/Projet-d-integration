using ApplicationTheather.Common.Interfaces.IRepository;
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
    public class SiegeRepository : Repository<Siege>, ISiegeRepository
    {
        ApplicationDbContext _dbcontext;
        public SiegeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext; 
        }

        public async Task<IEnumerable<Siege>> GetAllFromSalle(int salleId)
        {
            try
            {
                var entity=await _dbcontext.Siege
                                           .Where(x=>x.SalleId==salleId)
                                           .ToListAsync();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Siege>> GetFromListIds(List<int> SiegeIds)
        {
            try
            {
                return await _dbcontext.Siege.Where(x => SiegeIds.Contains(x.Id)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
