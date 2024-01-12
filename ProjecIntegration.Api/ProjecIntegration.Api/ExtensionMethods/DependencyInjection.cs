using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjecIntegration.Api.ApiService.Authorization;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.Infrastructure.Repository;
using System.Reflection;
using System.Security.Claims;

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

        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
        {
            //injection de la database 

            if (configuration.GetValue<bool>("InMemory"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDatabase"));

            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(option =>
                        option.UseSqlServer(configuration.GetConnectionString("ConnectionStrings")));
            }
            //injection des repository

            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<ICommandRepository, CommandRespository>();
            services.AddScoped<IComplexeRepository, ComplexeRepository>();
            services.AddScoped<IPrixRepository, PrixRespository>();
            services.AddScoped<ISalleDeTheatreRepository, SalleDeTheatreRepository>();
            services.AddScoped<IRepresentationRepository, RepresentationRespository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            //fin injection repository



            //fin injection service
            return services;
        }

        public static IServiceCollection AddAuthO(this IServiceCollection services, IConfiguration configuration)
        {
            var Domain= $"https://{configuration.GetValue<string>("AUTH0_DOMAIN")}/";
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder => {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var audience =
                      configuration.GetValue<string>("AUTH0_AUDIENCE");

                options.Authority =
                      Domain;
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });
            services.AddAuthorization(options =>
            {
                //-----AddPolicy
                options.AddPolicy("read:ticket",policy => policy
                .Requirements.Add(new HasScopeRequirement("read:ticket",Domain)));
                //-----AddPolicy
                options.AddPolicy("add:ticket", policy => policy
                .Requirements.Add(new HasScopeRequirement("add:ticket", Domain)));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
          return services;
        }
    }
}
