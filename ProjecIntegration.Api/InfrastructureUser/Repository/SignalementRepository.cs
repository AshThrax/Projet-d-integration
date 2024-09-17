using ApplicationUser.Repository;
using Domain.Entity.PublicationEntity.Modération;
using InfrastructureUser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    public class SignalementRepository : Repository<Signalement>, ISignalementRepository
    {
        public SignalementRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
