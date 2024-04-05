using ApplciationPublication.Common.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace ApplciationPublication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppPublication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PublicationProfile));//ajout du profile auto mapper pour les publication
            return services;
        }
    }
}
