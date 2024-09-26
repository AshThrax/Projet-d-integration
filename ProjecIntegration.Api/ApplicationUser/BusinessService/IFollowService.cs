using ApplicationUser.Dto;
using ApplicationUser.Dto.Follow;
using Domain.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Service
{
    public interface IFollowService
    {
        Task<ServiceResponse<GetFollowerDto>> AddFollower(AddFollowdto addFollowdto);
        Task<ServiceResponse<GetFollowerDto>> DeleteFollower(string UserId,string followerId);
        Task<ServiceResponse<IEnumerable<GetFollowerDto>>> GetAllFollower(string userId);
        Task<ServiceResponse<IEnumerable<GetFollowerDto>>> GetAllFollowed(string followId);


    }
}
