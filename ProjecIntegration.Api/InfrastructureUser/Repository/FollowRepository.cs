using ApplicationUser.Common.Repository;
using ApplicationUser.Dto.Follow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    public class FollowRepository : IFollowRepository
    {
        public Task AddFollow(AddFollowdto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFollower(string UserId, string FollowerId)
        {
            throw new NotImplementedException();
        }

        public Task GetFollower(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
