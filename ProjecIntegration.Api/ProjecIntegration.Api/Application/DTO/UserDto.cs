using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO
{
    public class UserDto :BaseDto ,IMapFrom<User>
    {
        

        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Email { get; set; }

        public IList<CommandDto> UserCommands { get; set; }
        public UserDto()
        {
            UserCommands = new List<CommandDto>();
        }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
            profile.CreateMap<UserDto, User>();
        }
    }
}
