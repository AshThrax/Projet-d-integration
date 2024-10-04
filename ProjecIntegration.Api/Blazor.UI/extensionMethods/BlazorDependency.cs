using Blazor.UI.data.services.Publication;
using Blazor.UI.data.services.TheatherService;
using Blazor.UI.Data.services.Annonce;
using Blazor.UI.Data.services.authorization;
using Blazor.UI.Data.services.Publication;
using Blazor.UI.Data.services.TheatherService;
using Blazor.UI.Data.Services.TheatherService;
using Blazor.UI.Data.Services.User;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

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
               
            }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>(); ;
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
            services.AddTransient<ICatalogueService, CataloguesService>();
            services.AddTransient < IThemeService , ThemeService > ();
            services.AddTransient<IAnnonceService, AnnonceService>();
            services.AddTransient<IPublicationService,PublicationService>();
            services.AddTransient<IPostService,PostService>();
            services.AddTransient<INotificaitonService,NotificationService>();
            services.AddTransient<IFavorisService, FavorisService>();
            services.AddTransient<IFeedBackService, FeedBackService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<IFollowService, FollowService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISiegeService, SiegeService>();
            return services;
        }
    }
}