using ApplicationUser.Dto.Favorit;
using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Service
{
    public interface IFavoritService : IService<Favorit,FavoritDto,AddFavoritDto,UpdateFavoritDto>
    {
    }
}
