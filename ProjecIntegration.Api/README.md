## technologies utilisée 

Blazor: utilisation de blazor entant qu'interface utilisa  teur 
server: implementation, d'un project .net 8 sdk
database: Sql Server 

## implémentation, Spécificité et dépendance

## Repository:

repository pattern générique
pour faciliter l'implementation de l'application
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
## Controlller:

un controlleur de donnée par entitée
pour plus de flexibilitée 
``` cs 
using data.Interfaces.IRepository;
namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComplexeController : ControllerBase
    {
        private readonly IComplexeRepository _complexeService;
        private readonly IMapper _mapper;
        public ComplexeController(
            IComplexeRepository complexeService,
            IMapper mapper)
        {
            _mapper=mapper;
            _complexeService = complexeService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById( int id)
        {
            try
            {
                var entity= await _complexeService.GetById(id, c =>c.SalleDeTheatres);
                var conversion = _mapper.Map<ComplexeDto>(entity);
                return Ok(conversion);

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ComplexeDto>>> GetAll() { 
        
            try
            {
                var entity = await _complexeService.GetAll(c => c.SalleDeTheatres);
                var conversion = _mapper.Map<IEnumerable<ComplexeDto>>(entity);
                return Ok(conversion);

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpPost]
        public ActionResult Create([FromBody] AddComplexeDto complexe)
        {
            Console.WriteLine("entering api ");
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<Complexe>(complexe);
                _complexeService.Insert(conversion);
                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(500, "pas d'argument");
            }
            catch (Exception e)
            {
                return StatusCode(500, "exception classique");
            }
        }
        [HttpPost("add-Salle/{idComplexe}")]
        public ActionResult AddSalle(int idComplexe,[FromBody] AddSalleDeTheatreDto salle)
        {
            Console.WriteLine("entering api ");
            try
            {
                if (salle == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<SalleDeTheatre>(salle);
                _complexeService.AddSalledeTheatre(idComplexe, conversion);
                return Ok();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpPut("{updtId}")]
        public ActionResult Update(int updtId, [FromBody] UpdateComplexeDto complexe)
        {
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<Complexe>(complexe);
                _complexeService.Update(updtId, conversion);
                return Ok();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {

                _complexeService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("delete-salle/{idComplexe}/{idSalle}")]
        public ActionResult Delete(int idComplexe,int idSalle)
        {
            try
            {
                _complexeService.DeletesalleDetheatre(idComplexe,idSalle);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
    }
}

```
## httpClient :

un services par entités present dans l'application

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
Dependance coté UIClient Blazor

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

les methodes repsonsable de l'injection de dependance se trouves pour le Client et pour le server dans le dossier extensionMethods.
ces Methodes sont ensuite appelée dans programmes.cs 
sous la forme suivante

``` cs
builder.services.AddDependencyInjection(builder.Configuration);
```
cette apporche permet de séparer les features dans un premier temps et de garder le project programme.cs propre.

#### Auth0:client
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

#### Auth0:server

la sécurisation de l'api via auth0 reste la meme que celle fournit par la doc de auth 0
c'est a dire 

``` cs
 public static IServiceCollection AddAuthO(this IServiceCollection services, IConfiguration configuration)
 {
     var Domain= configuration["Auth0:Domain"];//necessaire pour la sécurisation
     var Audience = configuration["Auth0:Audience"];//necessaire pour la sécurisation
     var Clientid = configuration["Auth0:ClientId"];//necessaire pour l'integration de la manageement api
     var ClientSecret = configuration["Auth0:ClientSecret"];//necessaire pour l'integration de la manageement api
//----------
     services.AddAuthentication(options =>
     {
         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//necessaire pour la sécurisation
         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//necessaire pour la sécurisation
         
     }).AddJwtBearer(options =>
     {
         options.Authority = Domain; //necessaire pour la sécurisation
         options.Audience = Audience; //necessaire pour la sécurisation
         options.TokenValidationParameters = new TokenValidationParameters /necessaire pour récuper le token
         {
             NameClaimType = ClaimTypes.NameIdentifier
         };
     });
     services.AddAuth0AuthenticationClient(options =>
     {
         options.Domain=Domain;//necessaire pour l'integration de la manageement api
         options.ClientId=Clientid;//necessaire pour l'integration de la manageement api
         options.ClientSecret=ClientSecret;//necessaire pour l'integration de la manageement api
     });
     services.AddAuth0ManagementClient()//permet l'utilisation de la management api
             .AddManagementAccessToken();//necessaire pour l'integration de la manageement api
     //---------------------------------
     services.AddAuthorization();//permet l'utilisation de la balisAuthorize 

     services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
     services.AddSingleton<ICustomGetToken, CustomGetToken>();//service permettant de tester l'authentification des                                                               //user sur l'application 
     return services;
 }
```
dans le cadre du project j'ai creer un service permettant de tester la récuperation du jwt totken du client via le server dans le cadre de l'integration su service
``` cs
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace WebApi.ApiService
{
    public interface ICustomGetToken
    {

        Task<string> GetToken();
        Task<string> GetSub();
        Task<string> GetEmail();
    }

    public  class CustomGetToken : ICustomGetToken
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CustomGetToken(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor 
                ?? throw new ArgumentNullException(nameof(_contextAccessor));
        }
        //retourne notre token
        public async Task<string> GetToken()
        {
            var accessToken = await _contextAccessor
                .HttpContext
                .GetTokenAsync("access_token");
            return accessToken;
            //acces token fonctionne parfaitemment
        }
        //retourne notre userId
        public async Task<string> GetSub() 
        {
            var accessToken = await _contextAccessor
               .HttpContext
               .GetTokenAsync("access_token");
            var subClaim = _contextAccessor.HttpContext
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return subClaim;
        }
        //retourne notre mail
        public async Task<string> GetEmail()
        {
            var values = _contextAccessor.HttpContext
                .User.FindFirst(ClaimTypes.CookiePath)?.Value;
            return values;
        }
    }
}

```
