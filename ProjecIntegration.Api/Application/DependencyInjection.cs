using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Dependencyinjection
    {

        public static IServiceCollection AddNotification(this IServiceCollection services)
        {
            return services;
        }
    }
}
