using ApplicationAnnonce.DTO;
using ApplicationUser.Dto.User;
using Auth0.ManagementApi.Models;
using Domain.ServiceResponse;
using UserDto = ApplicationUser.Dto.User.UserDto;

namespace WebApi.ApiService.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> GetById(string userId);
        Task<ServiceResponse<List<User>>> GetlistId(List<string> stringIds);
        Task<ServiceResponse<User>> DeleteId(string userId);
        Task<ServiceResponse<User>> UpdateById(string userId,UserUpdateRequest userDto);
        Task<ServiceResponse<User>> RemoveRoleById(string userId);
        Task<ServiceResponse<User>> AssignRoleById(string userId);
        Task<ServiceResponse<User>> BlockedUser(string userId);
    }
}
