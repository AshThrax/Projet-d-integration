using ApplicationAnnonce.DTO;
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace WebApi.ApiService
{
    public interface ICustomGetToken
    {

        Task<string> GetToken();
        Task<string> GetSub();
        Task<string> GetEmail();
        Task<UserDto> GetUser();    
    }

    public  class CustomGetToken : ICustomGetToken
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CustomGetToken(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor 
                ?? throw new ArgumentNullException(nameof(_contextAccessor));
        }
        public async Task<string?> GetToken()
        {
            try
            {
                string? accessToken = await _contextAccessor
                                            ?.HttpContext?
                                            .GetTokenAsync("access_token") 
                                            ?? throw new Exception("invalid token");

                return accessToken;

            }
            catch (Exception)
            {

                throw;
            }
            //acces token fonctionne parfaitemment
        }
        public async Task<string> GetSub() 
        {

            string? subClaim =  _contextAccessor?.HttpContext?
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            return subClaim ;
        }

        public async Task<string?> GetEmail()
        {
            try
            {
                string? values = _contextAccessor?.HttpContext?
                    .User.FindFirst(ClaimTypes.CookiePath)?.Value;
                return values;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserDto> GetUser()
        {
            UserDto getuser =new UserDto() 
            {
               Email= _contextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value,
               Picture= _contextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
               GivenName = _contextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value,
               FamilyName= _contextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "family_name")?.Value,
                UserName = _contextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "user_name")?.Value,
               User_id= _contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            };
            return getuser;
        }
    }
}
