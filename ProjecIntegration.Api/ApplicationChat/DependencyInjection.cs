using Microsoft.Extensions.DependencyInjection;

namespace ApplicationChat
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddChatApplication(this IServiceCollection service)
        {

            return service;
        }
    }
}
