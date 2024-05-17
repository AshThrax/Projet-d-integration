using Blazor.UI.data.services;
using Blazor.UI.data.services.Publication;
using Blazor.UI.data.services.TheatherService;

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

            services.AddTransient < IThemeService , ThemeService > ();
            services.AddTransient<IAnnonceService, AnnonceService>();
            services.AddTransient<IPublicationService,PublicationService>();
            services.AddTransient<IPostService,PostService>();
            services.AddTransient<INotificaitonService,NotificationService>();
            return services;
        }
    }
}