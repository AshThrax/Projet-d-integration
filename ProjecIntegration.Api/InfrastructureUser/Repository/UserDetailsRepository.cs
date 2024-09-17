using ApplicationUser.Repository;
using Domain.Entity.UserEntity.UserDetails;
using InfrastructureUser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    public class UserDetailsRepository : Repository<UserDetails>, IUserDetailRepository
    {
        public UserDetailsRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
