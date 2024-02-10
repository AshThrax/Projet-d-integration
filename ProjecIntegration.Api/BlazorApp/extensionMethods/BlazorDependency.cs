using Auth0.AspNetCore.Authentication;
using BlazorApp.data.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.extensionMethods
{
    public static class BlazorDependency
    {

        public static IServiceCollection AddBlazor(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            services.AddSignalR();          
            services.AddAuthService(configuration);
            services.CustomService();
            return services;
        } 
        public static IServiceCollection AddAuthService(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var aud = configuration["Auth0:Audience"];
            var dom = configuration["Auth0:Domain"];
            var cltd = configuration["Auth0:ClientId"];
            var clSt= configuration["Auth0:ClientSecret"];
            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = dom;
                options.ClientId = cltd;
                options.ClientSecret = clSt;
            });
            return services;
        }
        public static IServiceCollection CustomService(this IServiceCollection services)
        {
            services.AddHttpClient<IComplexeService, ComplexeService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:44364/api/Complexe");
            }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            services.AddHttpClient<ICommandService, CommandService>(c =>
          {
              c.BaseAddress = new Uri("https://localhost:44364/api/Command");
          }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();;
            services.AddHttpClient<IPieceService, PieceService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:44364/api/Piece");
            }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>(); ;
            services.AddHttpClient<ISalleService, SalleService>(c =>
          {
              c.BaseAddress = new Uri("https://localhost:44364/api/Salle");
          }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();;

            services.AddHttpClient<IRepresentationService, RepresentationService>(c =>
              {
                  c.BaseAddress = new Uri("https://localhost:44364/api/Represnetation");
              }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>(); ;

            return services;
        }
    }
}