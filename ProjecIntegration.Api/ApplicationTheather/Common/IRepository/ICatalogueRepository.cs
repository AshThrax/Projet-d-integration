using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.Common.IRepository
{
    public interface ICatalogueRepository : IRepository<Catalogue>
    {
        Task<IEnumerable<Catalogue>> GetCatalogueFromComplexe(int complexeId);
    }
}
