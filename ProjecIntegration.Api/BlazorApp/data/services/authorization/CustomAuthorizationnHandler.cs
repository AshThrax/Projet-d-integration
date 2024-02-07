using Microsoft.AspNetCore.Components;

namespace BlazorApp.data.services.authorization
{
    public class CustomAuthorizationnHandler
    {
        public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
        {
            public CustomAuthorizationMessageHandler(
                IAccessTokenProvider provider,
                NavigationManager navigation)
                : base(provider, navigation)
            {
                var url = "https://YOUR_API_URL"; // <-- insert your value here
                ConfigureHandler(authorizedUrls: new[] { url });
            }
        }
    }
}
