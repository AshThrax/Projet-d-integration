using ApplicationUser.Common.Repository;
using Domain.Entity.PublicationEntity.Modération;
using InfrastructureUser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    public class SignalementTypeRepository : Repository<SignalementType>, ISignalementTypeRepository
    {
        public SignalementTypeRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
