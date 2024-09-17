using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationTheather.DTO;
using ApplicationAnnonce.DTO;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using WebApi.ApiService.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize("Admin")]
    public class UserController : ControllerBase
    {

        private readonly IManagementApiClient _managementApiClient;
        private readonly ICustomGetToken _tok;
        public UserController(IManagementApiClient managementApiClient,ICustomGetToken tok) 
        {
            _managementApiClient = managementApiClient;
            _tok= tok;  
        }


    
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserID(string userId)
        {
            User apiClient = await _managementApiClient.Users.GetAsync(userId);
            UserDto dto = new UserDto()
            {
                Email = apiClient.Email,
                FamilyName = apiClient.LastName,
                GivenName = apiClient.FirstName,
                Name = apiClient.NickName,
                Picture = apiClient.Picture,
                UserName = apiClient.UserName,
                User_id = apiClient.UserId,
            };
            return Ok(dto);
        }
        [HttpDelete("userId")]
        public async Task<ActionResult> DeleteUserID(string userId)
        {
            var apiClient =  _managementApiClient.Users.DeleteAsync(userId);

            return  NoContent();
        }

    }
}
