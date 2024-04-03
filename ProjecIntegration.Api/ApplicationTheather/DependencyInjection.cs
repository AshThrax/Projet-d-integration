using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTheather
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTheatherApp(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
