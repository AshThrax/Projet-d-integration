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
    public class FavorisRepository : Repository<Favorit>, IFavoritRepository
    {
        public FavorisRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
