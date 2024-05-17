using ApplicationTheather.Common.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTheather
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTheatherApp(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(Mapping));
            return serviceCollection;
        }
    }
}
