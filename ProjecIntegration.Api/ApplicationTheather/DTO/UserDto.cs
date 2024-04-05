namespace WebApi.Application.DTO
{
    //class crée pour manager les user auth0
    //via la management Api
    public class UserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Blocked { get; set; }
    }
}
