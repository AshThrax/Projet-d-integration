using Application.Common.businessService;
using Application.Common.Repository;
using Infrastructure.BusinessService;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraNotif(this IServiceCollection services,IConfiguration configure) 
        {
            services.AddScoped<INotificationBl, NotificationBl>();
            services.AddScoped<INotificationRepository, NotificiationRepository>();
            services.AddScoped<IAnnonceRepository, AnnonceRepository>();
            services.Configure<NotificationStettings>(options =>
            {
                options.ConnectionString = configure.GetConnectionString("MongoDb");
                options.DatabaseName = "Notification";
            });
            return services;
        }
    }
}
