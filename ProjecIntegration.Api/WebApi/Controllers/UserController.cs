using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IManagementApiClient _managementApiClient;
        private readonly ICustomGetToken _tok;
        public UserController(IManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        [HttpGet]
        public async Task<UserDto> GetUserinfo()
        {
            var userid = _tok.GetSub();
            var user = await _managementApiClient.Users.GetAsync(userid.Result);
            UserDto userDto = new UserDto 
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Blocked= false
            };
            return userDto;
        }
        /* pour plus tard
            //admin methods
            [HttpGet]
            public async Task<IEnumerable<UserDto>> GetUsers()
            {
               // var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
          
            }   
         */
        [HttpPost]
        public async Task<ActionResult> UpdateUserInfo([FromBody] UserUpdateRequest request)
        {
            var userId = await _tok.GetSub();
            var UpdateUser = await _managementApiClient.Users.UpdateAsync(userId,request);
            return Ok();
        }
    }
}
