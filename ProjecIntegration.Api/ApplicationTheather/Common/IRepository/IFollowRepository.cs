using ApplicationUser.Dto.Follow;
using Domain.Entity.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Common.Repository
{
    public interface IFollowRepository
    {
        Task AddFollow(Follow dto);
        Task<IEnumerable<Follow>> GetFollower(string userId);
        Task<IEnumerable<Follow>> GetFollowed(string userId);
        Task DeleteFollower(string userId, string followerId);
        Task<bool> DoIFollow(string userId, string followerId);
    }
}
