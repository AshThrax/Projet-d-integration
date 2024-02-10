# Projet-d-integration
Projet de cours d'integration dans le cadre de mon cursus , ce projet est composé d'un projet asp.net core pour le back end et d'un projet angular  pour le front end


## Cahier des Charges
Une entreprise dédié à la gestion d’une marque de salle de théâtre nous demande de développer une application capable de gérer l'infrastructure de plusieurs complexe de salle de théâtre en Belgique :
-L’application sera capable de prendre les commandes d’un client en fonction d’une réservation, 
-De rechercher et  répertorier de nouvelle représentation et d'attribuer une place à chaque client,dans les différents complexes de salles de théâtre à travers le pays.

## Analyse Métier:
Solution proposé concernant le cahier des charge
La solution implémentée pour répondre à la demande du cahier des charge est la conception d’une application web composé d'une partie Back-End avec une approche code-first en .Net core et d’une partie Front -End en Angular. 
Dans le cadre du développement de ce projet , la méthodologie utilisée sera une méthodologie de type agile , Scrum. Cette méthodologie permettra d’avoir une plus grande flexibilité concernant le projet et son avancement.

## technologies utilisée 

-Blazor => utilisation de blazor entant qu'interface utilisa  teur 
-server => implementation, d'un project .net 8 sdk
-database Sql Server 

## design pattern 


-repository pattern générique
``` cs

```

httpClient :

``` cs

```

## coté server

dependance 
``` cs
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddApplication();
            services.AddInfrastructure(configuration);
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
       
        /*
        static methods in order to add authentication the programm.cs files
      */
        public static IServiceCollection AddAuthO(this IServiceCollection services, IConfiguration configuration)
        {
            var Domain= configuration["Auth0:Domain"];
            var Audience = configuration["Auth0:Audience"];
            var Clientid = configuration["Auth0:ClientId"];
            var ClientSecret = configuration["Auth0:ClientSecret"];
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
            services.AddAuth0AuthenticationClient(options =>
            {
                options.Domain=Domain;
                options.ClientId=Clientid;
                options.ClientSecret=ClientSecret;
            });
            services.AddAuth0ManagementClient()
                    .AddManagementAccessToken();
            //---------------------------------
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
```

coté UIClient Blazor

``` cs

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
```

