using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Infrastructure.Repository;

namespace ProjecIntegration.Api.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            //injection de Dependance des services 
            return services;
        }

        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services,IConfiguration configuration) 
        {
            //injection de la database 

            //injection des services / repository(

            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<ICommandRepository, CommandRespository>();
            services.AddScoped<IComplexeRepository, ComplexeRepository>();
            services.AddScoped<IPrixRepository, PrixRespository>();
            services.AddScoped<ISalleDeTheatreRepository, SalleDeTheatreRepository>();
            services.AddScoped<IRepresentationRepository,RepresentationRespository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            return services;
        }
        public static IServiceCollection AddAuthO(this IServiceCollection services,IConfiguration configuration) 
        {
            var domain = configuration["Auth0:Domain"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = configuration["Auth0:ApiIdentifier"];

            });
            services.AddAuthorization();
            return services; 
        }
    }
}
