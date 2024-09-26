using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.Common.IRepository
{
    public interface ISiegeRepository : IRepository<Siege>
    {
        Task<IEnumerable<Siege>> GetAllFromSalle(int salleId);

        Task<IEnumerable<Siege>> GetFromListIds(List<int> SiegeIds);
    }
}
