using ApplicationUser.Common.Repository;
using ApplicationUser.Dto.Follow;
using Domain.Entity.publicationEntity;
using Domain.Entity.UserEntity;
using InfrastructureUser.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly UserDbContext _userDbContext;

        public FollowRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task AddFollow(Follow dto)
        {
            try
            {
                await _userDbContext.Follows.AddAsync(dto);
                await _userDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteFollower(string userId, string followerId)
        {

            try
            {
               Follow followToDelete= await _userDbContext.Follows.Where(x => x.FollowId == userId && x.FollowerId == followerId)
                                                                  .FirstOrDefaultAsync() 
                                                                  ?? throw new NullReferenceException("no reference find");
                if (followToDelete != null)
                {
                    _userDbContext.Remove(followToDelete);
                    await _userDbContext.SaveChangesAsync();
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DoIFollow(string userId, string followerId)
        {
            try
            {
                Follow? getFollow = await _userDbContext.Follows.Where(x=>x.FollowId==userId && x.FollowerId==followerId).FirstOrDefaultAsync();

                return getFollow != null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Follow>> GetFollowed(string userId)
        {
            try
            {
                IEnumerable<Follow> GetFollowed = await _userDbContext.Follows.Where(x => x.FollowerId == userId)
                                                             .ToListAsync()
                                                             ?? throw new NullReferenceException("no reference find");
                return GetFollowed;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Follow>> GetFollower(string userId)
        {
            try
            {
                IEnumerable<Follow> GetFollower = await _userDbContext.Follows.Where(x => x.FollowId == userId)
                                                              .ToListAsync()
                                                              ?? throw new NullReferenceException("no reference find");
                return GetFollower;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
