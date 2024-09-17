using ApplicationTheather.Services;
using ApplicationUser.Repository;
using InfrastructureUser.Infrastructure;
using InfrastructureUser.Repository;
using InfrastructureUser.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureUser
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddUserInfrastructure(this IServiceCollection services,IConfiguration configuration) 
        {
            var conn = configuration.GetConnectionString("User");

            services.AddDbContext<UserDbContext>(option =>
               option.UseSqlServer(
               conn,
               b => b.MigrationsAssembly("WebApi")));
            //injection des repository
            services.AddRepository();
            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IFeedBackRepository,FeedbackRepository>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            return services;
        }

    }
}
