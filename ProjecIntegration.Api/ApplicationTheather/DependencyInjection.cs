using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.Common.Mapping;

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
