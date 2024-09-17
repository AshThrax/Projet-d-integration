using ApplicationUser.Common.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationUser
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddUserApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Automapper));//ajout du profile auto mapper pour les publication
            return services;
        }

    }
}
