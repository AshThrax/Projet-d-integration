using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorApp.data.services.authorization
{
  
        public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
        {
            public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
                NavigationManager navigationManager)
                : base(provider, navigationManager)
            {
                ConfigureHandler(
                   authorizedUrls: new[] { "https://localhost:44337" });

            }
        }
    
}
