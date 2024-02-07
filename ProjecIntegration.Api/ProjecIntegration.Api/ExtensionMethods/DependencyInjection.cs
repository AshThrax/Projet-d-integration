using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjecIntegration.Api.ApiService;
using ProjecIntegration.Api.ApiService.Authorization;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.Infrastructure.Repository;
using ProjecIntegration.Api.Models.Validator;
using System.Security.Claims;

namespace ProjecIntegration.Api.ExtensionMethods
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddApplication();
            services.AddInfrastrucutre(configuration);
            services.AddAuthO(configuration);
            services.AddCustomValidator();
            services.AddHttpContextAccessor();
            return services;
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //injection de Dependance des services 
            //injection automapper
            services.AddAutoMapper(typeof(Mapping));
            return services;
        }
        /*
            static methods in order to add authentication the programm.cs files
         */
        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
        {
            //injection de la database 

         
                services.AddDbContext<ApplicationDbContext>(option =>
                        option.UseSqlServer(configuration.GetConnectionString("Default")));
            
            //injection des repository

            
            services.AddScoped<ICommandRepository, CommandRespository>();
            services.AddScoped<IComplexeRepository, ComplexeRepository>();
            services.AddScoped<IPieceRepository, PieceRepository>();
            services.AddScoped<ISalleDeTheatreRepository, SalleDeTheatreRepository>();
            services.AddScoped<IRepresentationRepository, RepresentationRespository>();
            services.AddScoped<IPieceRepository, PieceRepository>();
            //fin injection repository



            //fin injection service
            return services;
        }
        /*
        static methods in order to add authentication the programm.cs files
      */
        public static IServiceCollection AddAuthO(this IServiceCollection services, IConfiguration configuration)
        {
            var Domain= configuration.GetValue<string>("Auth0:Domain");
            var Audience = configuration.GetValue<string>("Auth0:Audience");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options =>
            {
                options.Authority = Domain;
                options.Audience = Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

            services.AddAuthorization();

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddSingleton<ICustomGetToken, CustomGetToken>();
            return services;
        }
        /*
         static methods in order validator to the programm.cs files
         */
        public static IServiceCollection AddCustomValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddCommandDto>, AddCommandValidator>();
            services.AddScoped<IValidator<AddPieceDto>, AddPieceValidator>();
            services.AddScoped<IValidator<AddRepresentationDto>, AddRepresentationValidator>();
            services.AddScoped<IValidator<AddComplexeDto>, AddComplexeValidator>();
            services.AddScoped<IValidator<AddSalleDeTheatreDto>, AddSalleValidator>();
            //--------------------------
            services.AddScoped<IValidator<UpdateCommandDto>, UpdtCommandValidator>();
            services.AddScoped<IValidator<UpdateComplexeDto>, UpdtComplexeValidator>();
            services.AddScoped<IValidator<UpdatePieceDto>, UpdtPieceValidator>();
            services.AddScoped<IValidator<UpdateRepresentationDto>, UpdtRepresentationValidator>();
            services.AddScoped<IValidator<UpdateSalleDeTheatreDto>, UpdtSalleValidator>();
            return services;
        }
    }
}
