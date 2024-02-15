using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


