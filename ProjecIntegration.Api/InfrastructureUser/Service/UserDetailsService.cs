using ApplicationUser.Dto.Base;
using ApplicationUser.Dto.UserDetails;
using ApplicationUser.Repository;
using ApplicationUser.Service;
using AutoMapper;
using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Service
{
    public class UserDetailsService : Service<UserDetails,GetUserDetailsDto, AddUserDetailDto, UpdateUserDetailDto>,IUserDetailService
    {
        private readonly IUserDetailRepository repository;
        public UserDetailsService(IUserDetailRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }
    }
}
