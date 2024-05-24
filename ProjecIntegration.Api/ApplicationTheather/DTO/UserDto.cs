namespace ApplicationTheather.DTO
{
    //class crée pour manager les user auth0
    //via la management Api
    public static class UserDto
    {
        public class Index
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool Blocked { get; set; }
        }
    }
}
