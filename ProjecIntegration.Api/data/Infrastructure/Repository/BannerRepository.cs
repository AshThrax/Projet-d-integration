using ApplicationUser.Common.IRepository;
using Domain.Entity.UserEntity;
using InfrastructureUser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    class BannerRepository : Repository<Banner>, IBannerRepository
    {
        public BannerRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
