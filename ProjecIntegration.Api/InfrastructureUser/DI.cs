using ApplicationUser.BusinessService.Banner;
using ApplicationUser.BusinessService.FeedBack;
using ApplicationUser.BusinessService.Follow;
using ApplicationUser.Common.IRepository;
using ApplicationUser.Common.Repository;
using ApplicationUser.Service;
using InfrastructureUser.BusinessService;
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
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            //-------Feedback
            services.AddScoped<IFeedBackRepository,FeedbackRepository>();
            services.AddScoped<IFeedBackService, FeedBackService>();
       
            //------Follow
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IFollowService, FollowService>();
            //------Banner
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerService, BannerService>();
            //------Signalement------
            services.AddScoped<ISignalementRepository, SignalementRepository>();
            services.AddScoped<ISignalementService, SignalementService>();
            //------Signalement------
            services.AddScoped<ISignalementTypeRepository, SignalementTypeRepository>();
            services.AddScoped<ISignalementTypeService, SignalementTypeService>();

            return services;
        }

    }
}
