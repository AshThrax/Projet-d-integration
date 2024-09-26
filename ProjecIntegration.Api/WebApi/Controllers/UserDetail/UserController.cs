using ApplicationUser.Dto.User;
using Auth0.ManagementApi.Models;
using Domain.ServiceResponse;
using WebApi.ApiService.UserService;

namespace WebApi.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
//[Authorize("Admin")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService; 
    public UserController(IUserService userService)
    {
           _userService = userService;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    public async Task<ActionResult> GetUserId(string userId)
    {
        try
        {
            ServiceResponse<User> response = await _userService.GetById(userId);
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
    [HttpGet()]
    public async Task<ActionResult> GetUserID([FromQuery] List<string> userIds)
    {
       try
       {
            ServiceResponse<List<User>> response = await _userService.GetlistId(userIds);
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
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("userId")]
    public async Task<ActionResult> DeleteUserID(string userId)
    {
        try
        {
            ServiceResponse<User> response = await _userService.DeleteId(userId);
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

}

