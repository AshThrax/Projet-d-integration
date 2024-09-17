using ApplicationUser.Dto.Base;
using ApplicationUser.Dto.UserDetails;
using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Service
{
    public interface IUserDetailService : IService<UserDetails,GetUserDetailsDto,AddUserDetailDto,UpdateUserDetailDto>
    {
    }
}
