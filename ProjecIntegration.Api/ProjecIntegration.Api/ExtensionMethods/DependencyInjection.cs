using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Infrastructure.Repository;
using ProjecIntegration.Api.Infrastructure.Service;
using System.Reflection;

namespace ProjecIntegration.Api.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            //injection de Dependance des services 
            //injection automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services,IConfiguration configuration) 
        {
            //injection de la database 

            //injection des repository

            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<ICommandRepository, CommandRespository>();
            services.AddScoped<IComplexeRepository, ComplexeRepository>();
            services.AddScoped<IPrixRepository, PrixRespository>();
            services.AddScoped<ISalleDeTheatreRepository, SalleDeTheatreRepository>();
            services.AddScoped<IRepresentationRepository,RepresentationRespository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            //fin injection repository

            //injection des Services
            services.AddScoped<ICatalogueService, CatalogueService>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IComplexeService, ComplexeService>();
            services.AddScoped<IPrixService,PrixService>();
            services.AddScoped<ISalleDeTheatreSevice, SalleDeTheatreService>();
            services.AddScoped<IRepresentationService, RepresentationService>();
            services.AddScoped<ITicketService, TicketService>();
            //fin injection service
            return services;
        }
        public static IServiceCollection AddAuthO(this IServiceCollection services,IConfiguration configuration) 
        {
            //----injection----service Auth0
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
