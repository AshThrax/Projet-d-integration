using ApplicationTheather.Common.Mapping.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTheather
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTheatherApp(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(Theatre));
            return serviceCollection;
        }
    }
}
