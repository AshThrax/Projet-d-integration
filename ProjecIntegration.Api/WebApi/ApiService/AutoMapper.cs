namespace WebApi.ApiService
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            _ = CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
