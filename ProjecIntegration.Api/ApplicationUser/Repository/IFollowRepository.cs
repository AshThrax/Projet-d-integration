using ApplicationUser.Dto.Follow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Repository
{
    public interface IFollowRepository
    {
        Task AddFollow(AddFollowdto dto);
        Task GetFollower(string UserId);
        Task DeleteFollower(string UserId,string FollowerId);
    }
}
