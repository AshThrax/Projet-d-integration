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

## implémentation et dépendance


-repository pattern générique
``` cs
namespace data.Interfaces.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T entity);
        void Update(int updtId, T entity);
        void Delete(int entityid);
    }
}
///// implementation
namespace data.Infrastructure.Repository
{
    public class RepresentationRespository : Repository<Representation>, IRepresentationRepository
    {
        private readonly ApplicationDbContext _context;

        public RepresentationRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void AddCommandToRepresentation(int idRepresentation, Command command)
        {
            var representation = _context.Representations.FirstOrDefault(r => r.Id == idRepresentation);

            if (representation != null)
            {
                if (representation.Commands == null)
                {
                    representation.Commands = new List<Command>();

                }
                //chaque fois qu'on ajoute une commande le nombre de place diminiue
                var place = command.Tickets.Count;
                representation.placeCurrent=representation.placeCurrent+place;
                representation.Commands.Add(command);
                _context.SaveChanges();
            }
        }

        public void DeleteCommandRepresnetation(int idrepresentation, int CommandId)
        {
            var representation = _context.Representations
                .FirstOrDefault(r => r.Id == idrepresentation);
            
            if (representation != null)
            {

                var Commanddelete = representation
                    .Commands.FirstOrDefault(r => r.Id == CommandId);

                //chaque fois qu'on supprime une commande le nombre de place dispo pour la reservation augmente
                var place =Commanddelete.Tickets.Count;
                representation.placeCurrent=representation.placeCurrent-place;
                representation.Commands.Remove(Commanddelete) ;
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Representation>> GetAllByPieceId(int idPIece)
        {
           var piece= _context.Pieces.Include(c =>c.Representations)
               .Where(c => c.Id == idPIece)
                .FirstOrDefault();
            if (piece != null)
            {
                var result = piece.Representations;
                return result;
            }

            return null; 
        }
        public async Task<IEnumerable<Representation>> GetAllBySalleId(int idSalle)
        {
            var salle= await _context.SalleDeTheatres
                .Include(c =>c.Representations)
                .Where(c =>c.Id==idSalle)
                .FirstOrDefaultAsync();

            var Entities = salle.Representations;
            return Entities;
        }
    }
}


```

httpClient :

``` cs
//exemple des service httpclient coté  client
    public interface IPieceService 
    {
        Task<IEnumerable<PieceDto>> Get();
        Task<PieceDto> GetById(int id);
        Task<IEnumerable<PieceDto>> GetByComplexe(int id);
        Task Create(AddPieceDto data);
        Task AddRepresentation(int idPiece, AddRepresentationDto data);
        Task Update(int id, UpdatePieceDto data);
        Task Delete(PieceDto data);
        Task DeleteRepresentation(int idPiece, int idRepresentation);
    }

    public class PieceService : IPieceService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUri = "https://localhost:44337/api/Piece";
     
        public PieceService(HttpClient httpClient)
        {

            _httpClient = httpClient;
            
        }

        public async Task<IEnumerable<PieceDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto>>(ApiUri);
        }

        public async Task<PieceDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<PieceDto>($"{ApiUri}/{id}");
        }

        public async Task<IEnumerable<PieceDto>> GetByComplexe(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PieceDto>>($"{ApiUri}/get-complexe/{id}");
        }

        public async Task Create(AddPieceDto data)
        {
            await _httpClient.PostAsJsonAsync(ApiUri, data);
        }

        public async Task AddRepresentation(int idPiece, AddRepresentationDto data)
        {
            await _httpClient.PostAsJsonAsync($"{ApiUri}/add-representation/{idPiece}", data);
        }

        public async Task Update(int id, UpdatePieceDto data)
        {
            await _httpClient.PutAsJsonAsync($"{ApiUri}/{id}", data);
        }

        public async Task Delete(PieceDto data)
        {
            await _httpClient.DeleteAsync(ApiUri);
        }

        public async Task DeleteRepresentation(int idPiece, int idRepresentation)
        {
            await _httpClient.DeleteAsync($"{ApiUri}/delete-representation/{idPiece}/{idRepresentation}");
        }
```

## coté server

Dependance project WebApi
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
Dependance dans la classe librairie data 
``` cs

namespace data
{
    public  static class DependencyInjection
    {

              public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
              {
            //injection de la database 

                     var conn = configuration.GetConnectionString("Default");

                         services.AddDbContext<ApplicationDbContext>(option =>
                            option.UseSqlServer(
                            (conn),
                            b => b.MigrationsAssembly("WebApi")));
                    //injection des repository

                    services.AddScoped<ICommandRepository, CommandRespository>();
                    services.AddScoped<IComplexeRepository, ComplexeRepository>();
                    services.AddScoped<IPieceRepository, PieceRepository>();
                    services.AddScoped<ISalleDeTheatreRepository, SalleDeTheatreRepository>();
                    services.AddScoped<IRepresentationRepository, RepresentationRespository>();
                    services.AddScoped<IPieceRepository, PieceRepository>();
                    //fin injection reposi
                    //fin injection service
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

le systéme d'authentification géré avec auth0 
l'integration d'auth0 sur un project blazor web assembly  demande des ajustements bien précis 

### injection de dependant dans blazor 

#### Auth0
l'integration de blazor a auth0 nécéssite l'utilisation d'openId Connect
pour fonctionner correctemment
``` cs
   public static IServiceCollection AddAuthService(this IServiceCollection services,
                                               IConfiguration configuration)
   {
       
       //oidc
       services.AddOidcAuthentication(option => {
           configuration.Bind("Auth0", option.ProviderOptions);
           option.ProviderOptions.ResponseType = "code";
           option.ProviderOptions.DefaultScopes.Add("email");
           option.ProviderOptions.AdditionalProviderParameters.Add("audience", configuration["Auth0:Audience"] );
       });
       return services;
   }
```
l'injection du jwt token se fait via la créarion d'un middleware dédié a cela ,
si vous utiliser une api.net comme part i server et non un project blazor.server vous devez opµbligatoirement creer un middleware comme ceci :

``` cs
 
        public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
        {
            public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
                NavigationManager navigationManager)
                : base(provider, navigationManager)
            {
                ConfigureHandler(
                   authorizedUrls: new[] { "my_api_url_netcore" });

            }
        }
```

une fois le middleware creer il doit être injecter dans les requète http, de la manière suivante 
``` cs

 builder.Services.AddTransient<CustomAuthorizationMessageHandler>(); //
//inject in all htpcclient my jwt token in my header allowing my request to be validated in my
//api side 
builder.Services.AddHttpClient("projectAPI",client => //you need to register your api  base url here
                 client.BaseAddress = new Uri("my_api_url_netcore" ))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>()
                                        .CreateClient("projectAPI"));

```
cette methodes permet d'injecter automatiquement un jwttoken a toute les requeste faites vers l'url de votre api
