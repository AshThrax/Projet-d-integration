using Amazon.Runtime.Internal;
using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Common.Repository;
using InfraPublication.BusinessLayer;
using InfraPublication.Persistence;
using InfraPublication.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InfraPublication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraPublication(this IServiceCollection service,IConfiguration configure)
        {
            service.AddScoped<IPublicationRepository, PublicationRepository>();
            service.AddScoped<IPostRepository, PostRepository>();
            service.AddScoped<IPublicationBl, IPublicationBL>();
            service.Configure<PublicationSetttings>(options => 
            {
                options.ConnectionString = configure.GetConnectionString("MongoDb");
                options.DatabaseName = "Publication";
            });

           
            return service;
        }
    }
}
