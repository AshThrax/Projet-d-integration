using Blazor.UI.services;
using Blazor.UI.services;
using Blazor.UI.services;
using BlazorApp.data.services.authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Blazor.UI.extensionMethods
{
    public static class BlazorDependency
    {

        public static IServiceCollection AddBlazor(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
          

            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                                                    .CreateClient("projectAPI"));
            services.AddAuthService(configuration);
            services.CustomService();
            return services;
        } 
        public static IServiceCollection AddAuthService(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            
            //oidc
            services.AddOidcAuthentication(option => {
                configuration.Bind("Auth0", option.ProviderOptions);
                option.ProviderOptions.ResponseType = "code";
                option.ProviderOptions.DefaultScopes.Add("email");
                option.ProviderOptions.AdditionalProviderParameters.Add("audience", "https://hello-world.example.com" );
            });
            return services;
        }
        public static IServiceCollection CustomService(this IServiceCollection services)
        {

            services.AddTransient<IComplexeService, ComplexeService>();
            ;
            services.AddTransient<ICommandService, CommandService>();
            ;


            services.AddTransient<IPieceService, PieceService>();
            ;

            services.AddTransient<ISalleService, SalleService>();
            ;

            services.AddTransient<IRepresentationService, RepresentationService>();
            ;




            return services;
        }
    }
}