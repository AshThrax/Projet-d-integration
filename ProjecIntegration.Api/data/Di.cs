using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using DataInfraTheather.BusinessService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dataInfraTheather
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //injection de la database 

            var conn = configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationDbContext>(option =>
               option.UseSqlServer(
               conn,
               b => b.MigrationsAssembly("WebApi")));
            //injection des repository

            services.AddBusiness();
            //fin injection reposi
            //fin injection service
            return services;
        }
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICommandRepository,CommandRespository>();
            services.AddScoped<IRepresentationRepository, RepresentationRespository>();
            services.AddScoped<IComplexeRepository,ComplexeRepository>();
            services.AddScoped<IPieceRepository,PieceRepository>();
            services.AddScoped<ISalleDeTheatreRepository, SalleDeTheatreRepository>();
            

            services.AddScoped<IBusinessCommandService, BusinessCommandService>();//commande services user
            services.AddScoped<IBusinessRepresentation, BusinessRepresntation>();//Represnetation business Service
            services.AddScoped<IBusinessSalle, BusinessSalle>();//Business Salle Services
            services.AddScoped<IBusinessComplexe, BusinessComplexe>(); //business Complexe Service
            services.AddScoped<IBusinessPiece, BusinessPiece>(); //Business Piece Service
            services.AddScoped<ITheatreBusiness, TheatreBusiness>(); //Business THeatre Service
            return services;
        }
    }
}


