using ApplicationAnnonce.Common.Repository;
using ApplicationTheater.Common;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataInfraTheather.Infrastructure.Repository
{
    public class AnnonceRepository : Repository<Annonce>, IAnnonceRepository
    {
        public AnnonceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
