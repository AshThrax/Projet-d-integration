using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationTheather.Common.Interfaces.IRepository;
using InfraPublication.BusinessLayer;
using InfraPublication.Infrastructure.Repository;
using InfraPublication.Persistence;
using InfraPublication.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraPublication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraPublication(this IServiceCollection services,IConfiguration configure)
        {
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRepostRepository, RepostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRepostBL, RepostBL>();
            services.AddScoped<IPostBL, PostBL>();
            services.AddScoped<IPublicationBl, PublicationBL>();
            services.Configure<PublicationSetttings>(options => 
            {
                options.ConnectionString = configure.GetConnectionString("MongoDb");
                options.DatabaseName = "Publication";
            });

           services.AddSingleton<PublicationMongoContext>();
            return services;
        }
    }
}
