using ApplicationAnnonce.Common.mapping;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationAnnonce
{
    public static class Dependencyinjection
    {

        public static IServiceCollection AddAppNotifi(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NotifProfile));
            return services;
        }
    }
}
