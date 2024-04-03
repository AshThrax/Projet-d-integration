using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services) 
        {
            return services;
        }
    }
}
