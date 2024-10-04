using ApplicationUser;
using InfrastructureUser;
using WebApi.ApiService.PaymentService;
using WebApi.ApiService.UserService;

namespace WebApi.ExtensionMethods
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure(configuration);
            //ajoout des service liée au service  notification
            services.AddAppNotifi();
            services.AddInfraNotif(configuration);
            //ajout des service liée au service de publication
            services.AddAppPublication();
            services.AddInfraPublication(configuration);
            //ajout des Servide liée au service utilisateur
            services.AddUserApplication();
            services.AddUserInfrastructure(configuration);
            //ajout service auth0
            services.AddAuthO(configuration);
            //ajout des custom Validator
            services.AddCustomValidator();
            services.AddHttpContextAccessor();
            services.AddBusiness();
            services.AddSignalR();
            services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));
            services.AddAutoMapper(typeof(UserMapper));
            return services;
        }
        /*
         * injection des business services en tant que service dans l'application
         */
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IBusinessCommandService, BusinessCommandService>();//commande services user
            services.AddScoped<IBusinessRepresentation, BusinessRepresntation>();//Represnetation business Service
            services.AddScoped<IBusinessSalle, BusinessSalle>();//Business Salle Services
            services.AddScoped<IBusinessComplexe, BusinessComplexe>(); //business Complexe Service
            services.AddScoped<IBusinessPiece, BusinessPiece>(); //Business Piece Service
            services.AddScoped<ITheatreBusiness, TheatreBusiness>(); //Business THeatre Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();
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

        /*
        static methods in order to add authentication the programm.cs files
      */
        public static IServiceCollection AddAuthO(this IServiceCollection services, IConfiguration configuration)
        {
            string? Domain = configuration["Auth0:Authority"];
            string? Audience = configuration["Auth0:ApiIdentifier"];
            string? Clientid = configuration["Auth0:ClientId"];
            string? ClientSecret = configuration["Auth0:ClientSecret"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = Domain;
                options.Audience = Audience;
               
                
            });
            services.AddAuth0AuthenticationClient(options =>
            {
                options.Domain = configuration["Auth0:Authority"];
                options.ClientId = configuration["Auth0:ClientId"];
                options.ClientSecret = configuration["Auth0:ClientSecret"];
            });

            services.AddAuth0ManagementClient()
                    .AddManagementAccessToken();
            //---------------------------------
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
