using ApplicationUser.BusinessService.Follow;
using ApplicationUser.Common.Repository;
using ApplicationUser.Dto;
using ApplicationUser.Dto.Follow;
using AutoMapper;
using Domain.Entity.publicationEntity;
using Domain.Entity.UserEntity;
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
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        public FollowService(IFollowRepository followRepository, IMapper mapper)
        {
            this._followRepository = followRepository;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse<GetFollowerDto>> AddFollower(AddFollowdto addFollowdto)
        {
            ServiceResponse<GetFollowerDto> response = new();
            try
            {
                Follow follow = new()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    FollowId = addFollowdto.FollowId,
                    FollowerId = addFollowdto.FollowerId,
                };
                await _followRepository.AddFollow(follow);

                response.Success = true;
                response.Data = null;
                response.Message = "operation successfull";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<GetFollowerDto>> DeleteFollower(string UserId, string FollowerId)
        {
            ServiceResponse<GetFollowerDto> response = new();
            try
            {
                await _followRepository.DeleteFollower(UserId,FollowerId);

                response.Success = true;
                response.Data = null;
                response.Message = "operation successfull";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<IEnumerable<GetFollowerDto>>> GetAllFollower(string userId)
        {
            ServiceResponse<IEnumerable<GetFollowerDto>> response = new();
            try
            {
               IEnumerable<Follow>GetFollower= await _followRepository.GetFollower(userId);

                response.Success = true;
                response.Data = _mapper.Map<IEnumerable<GetFollowerDto>>(GetFollower);
                response.Message = "operation successfull";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ServiceResponse<IEnumerable<GetFollowerDto>>> GetAllFollowed(string userId)
        {
            ServiceResponse<IEnumerable<GetFollowerDto>> response = new();
            try
            {
                IEnumerable<Follow> GetFollower = await _followRepository.GetFollowed(userId);

                response.Success = true;
                response.Data = _mapper.Map<IEnumerable<GetFollowerDto>>(GetFollower);
                response.Message = "operation successfull";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<bool>> DoIFollow(string userId, string followerId)
        {
            ServiceResponse<bool> response = new();
            try
            {
                bool DoIfollow = await _followRepository.DoIFollow(userId,followerId);

                response.Success = true;
                response.Data = DoIfollow;
                response.Message = "operation successfull";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
