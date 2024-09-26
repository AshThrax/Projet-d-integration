using ApplicationUser.Dto;
using ApplicationUser.Dto.Follow;
using ApplicationUser.Service;
using Domain.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Service
{
    public class FollowService : IFollowService
    {
        public Task<ServiceResponse<GetFollowerDto>> AddFollower(AddFollowdto addFollowdto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetFollowerDto>> DeleteFollower(string UserId, string FollowerId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<GetFollowerDto>>> GetAllFollower(string UserId)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<IEnumerable<GetFollowerDto>>> GetAllFollowed(string followId)
        {
            throw new NotImplementedException();
        }
    }
}
