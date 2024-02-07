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
    }

    public  class CustomGetToken : ICustomGetToken
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CustomGetToken(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor 
                ?? throw new ArgumentNullException(nameof(_contextAccessor));
        }
        public async Task<string> GetToken()
        {
            var accessToken = await _contextAccessor
                .HttpContext
                .GetTokenAsync("access_token");
            return accessToken;
            //acces token fonctionne parfaitemment
        }
        public async Task<string> GetSub() 
        {
            var accessToken = await _contextAccessor
               .HttpContext
               .GetTokenAsync("access_token");
            var subClaim = _contextAccessor.HttpContext
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return subClaim;
        }

        public async Task<string> GetEmail()
        {
            var values = _contextAccessor.HttpContext
                .User.FindFirst(ClaimTypes.CookiePath)?.Value;
            return values;
        }
    }
}
