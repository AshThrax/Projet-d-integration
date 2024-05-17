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
            try
            {
                string? accessToken = await _contextAccessor
                                            .HttpContext
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
            string? accessToken = await _contextAccessor
                                        ?.HttpContext.GetTokenAsync("access_token") ?? "";

            string? subClaim = _contextAccessor.HttpContext
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            return subClaim ;
        }

        public async Task<string> GetEmail()
        {
            try
            {
                string? values = _contextAccessor.HttpContext
                    .User.FindFirst(ClaimTypes.CookiePath)?.Value;
                return values;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
