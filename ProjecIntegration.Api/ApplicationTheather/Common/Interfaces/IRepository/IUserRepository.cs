
using ApplicationTheater.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(string Id);
        Task DeleteUser(string userId);
        Task Update(string userId, UserDto user);
    }
}
