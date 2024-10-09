using ApplicationUser.Dto;
using ApplicationUser.Dto.Follow;
using Domain.ServiceResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Follow
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;
        private readonly ICustomGetToken _customGetToken;
        public FollowController(IFollowService followService, ICustomGetToken customGetToken)
        {
            _followService = followService;
            _customGetToken = customGetToken;
        }
        /// <summary>
        /// add new follow to a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetFollowerDto>>> AddFollow(string followerId)
        {
            ServiceResponse<GetFollowerDto> response =new ServiceResponse<GetFollowerDto>();
            try
            {
                string userId = await _customGetToken.GetSub();
                AddFollowdto addFollow= new AddFollowdto 
                {
                    FollowerId = userId,
                    FollowId = userId,
                };
                response = await _followService.AddFollower(addFollow);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// erase a follower
        /// </summary>
        /// <param name="followerId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetFollowerDto>>> DeleteFollow(string followerId)
        {
            ServiceResponse<GetFollowerDto> response = new ServiceResponse<GetFollowerDto>();
            try
            {
                string userId = await _customGetToken.GetSub();
                response = await _followService.DeleteFollower(userId, followerId);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get All the follower
        /// </summary>
        /// <returns></returns>
        [HttpGet("follower/{userId}")]
        public async Task<ActionResult<ServiceResponse<GetFollowerDto>>> GetFollower(string userId)
        {
            ServiceResponse<IEnumerable<GetFollowerDto>> response = new();
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    userId = await _customGetToken.GetSub();

                }
                response = await _followService.GetAllFollower(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        /// <summary>
        /// get All the follower
        /// </summary>
        /// <returns></returns>
        [HttpGet("followed/{userId}")]
        public async Task<ActionResult<ServiceResponse<GetFollowerDto>>> GetFollowed(string userId)
        {
            ServiceResponse<IEnumerable<GetFollowerDto>> response = new ();
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    userId= await _customGetToken.GetSub();

                }
                response = await _followService.GetAllFollowed(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpGet("do-i-follow")]
        public async Task<ActionResult<ServiceResponse<bool>>> DoIFollow(string followerId)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                string userId = await _customGetToken.GetSub();
                response= await _followService.DoIFollow(userId,followerId);
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
    }
}
