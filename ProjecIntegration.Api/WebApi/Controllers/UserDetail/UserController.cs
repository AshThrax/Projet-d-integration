using ApplicationUser.Dto.User;
using Auth0.ManagementApi.Models;
using Domain.Entity.publicationEntity;
using Domain.ServiceResponse;
using WebApi.ApiService.UserService;

namespace WebApi.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
//[Authorize("Admin")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService; 
    private readonly ICustomGetToken _customGetToken;
    public UserController(IUserService userService, ICustomGetToken customGetToken)
    {
           _userService = userService;
           _customGetToken = customGetToken;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    public async Task<ActionResult<ServiceResponse<ApplicationUser.Dto.User.UserDto>>> GetUserId(string userId)
    {
        try
        {
            ServiceResponse<ApplicationUser.Dto.User.UserDto> response = await _userService.GetById(userId);
            if (!response.Success)
            {
               return BadRequest(response.Message);      
            }
            return Ok(response);

        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userIds"></param>
    /// <returns></returns>
    [HttpGet("fromlist")]
    public async Task<ActionResult> GetUserIds([FromQuery] List<string> userIds)
    {
       try
       {
            ServiceResponse<List<ApplicationUser.Dto.User.UserDto>> response = await _userService.GetlistId(userIds);
            if (!response.Success)
            {
                    return BadRequest(response.Message);
            }
            return Ok(response);
       }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    /// <summary>
    /// delete a user fromt the app
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("userId")]
    public async Task<ActionResult> DeleteUserID(string userId)
    {
        try
        {
            ServiceResponse<Auth0.ManagementApi.Models.User> response = await _userService.DeleteId(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    [HttpPut]
    public async Task<ActionResult> UpdateUserInformation([FromBody] UpdateUserDto userToupdate)
    {
        try
        {
            if (userToupdate == null)
            {
                return BadRequest();
            }
            string userId = await _customGetToken.GetSub();
             userId = "google-oauth2|101722961601467374459";
            await _userService.UpdateById(userId,userToupdate);
            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    ///  block a user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut("/block/{userId}")]
    public async Task<ActionResult> BlockUser(string userId)
    {
        try
        {
            ServiceResponse<Auth0.ManagementApi.Models.User> response = await _userService.BlockedUser(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// unblock a user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut("/unblock/{userId}")]
    public async Task<ActionResult> UnBlockUser(string userId)
    {
        try
        {
            ServiceResponse<Auth0.ManagementApi.Models.User> response = await _userService.UnBlockedUser(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// nominate a user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut("/unnom-admin/{userId}")]
    public async Task<ActionResult> UnNominateAdmin(string userId)
    {
        try
        {
            ServiceResponse<Auth0.ManagementApi.Models.User> response = await _userService.RemoveRoleById(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// unnominate an admin
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut("/nom-admin/{userId}")]
    public async Task<ActionResult> Nominateadmin(string userId)
    {
        try
        {
            ServiceResponse<Auth0.ManagementApi.Models.User> response = await _userService.AssignRoleById(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
}

