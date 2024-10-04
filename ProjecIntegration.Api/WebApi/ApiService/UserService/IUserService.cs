using ApplicationAnnonce.DTO;
using ApplicationUser.Dto.User;
using Auth0.ManagementApi.Models;
using Domain.ServiceResponse;
using UserDto = ApplicationUser.Dto.User.UserDto;

namespace WebApi.ApiService.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<UserDto>> GetById(string userId);
        Task<ServiceResponse<List<UserDto>>> GetlistId(List<string> stringIds);
        Task<ServiceResponse<User>> DeleteId(string userId);
        Task<ServiceResponse<User>> UpdateById(string userId,UpdateUserDto userDto);
        Task<ServiceResponse<User>> RemoveRoleById(string userId);
        Task<ServiceResponse<User>> AssignRoleById(string userId);
        Task<ServiceResponse<User>> BlockedUser(string userId);
        Task<ServiceResponse<User>> UnBlockedUser(string userId);
    }
}
