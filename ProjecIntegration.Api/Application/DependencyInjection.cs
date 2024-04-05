using Application.Common.mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Application
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
