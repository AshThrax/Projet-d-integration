using ApplicationPublication.Common.Repository;
using ApplicationTheater.Common;
using ApplicationTheather.BusinessService;
using ApplicationTheather.BusinessService.Catalogue;
using ApplicationTheather.BusinessService.Command;
using ApplicationTheather.BusinessService.Complexe;
using ApplicationTheather.BusinessService.Piece;
using ApplicationTheather.BusinessService.Representation;
using ApplicationTheather.BusinessService.Salle;
using ApplicationTheather.BusinessService.Theme;
using ApplicationTheather.Common.IRepository;
using ApplicationUser.BusinessService.Banner;
using ApplicationUser.BusinessService.FeedBack;
using ApplicationUser.BusinessService.Follow;
using ApplicationUser.Common.IRepository;
using ApplicationUser.Common.Repository;
using ApplicationUser.Service;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using DataInfraTheather.BusinessService;
using DataInfraTheather.Infrastructure.Repository;
using InfraPublication.BusinessLayer;
using InfraPublication.BusinessService;
using InfraPublication.Repository;
using InfrastructureUser.BusinessService;
using InfrastructureUser.Repository;
using InfrastructureUser.Service;
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
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<ISiegeRepository, SiegeRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<ICataloguePieceRepository, CataloguePieceRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<ISiegeCommandRepository, SiegeCommandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFavorisrepository, FavorisRepository>();

            services.AddScoped<IBusinessCommandService, BusinessCommandService>();//commande services user
            services.AddScoped<IBusinessRepresentation, BusinessRepresntation>();//Represnetation business Service
            services.AddScoped<IBusinessSalle, BusinessSalle>();//Business Salle Services
            services.AddScoped<IBusinessComplexe, BusinessComplexe>(); //business Complexe Service
            services.AddScoped<IBusinessPiece, BusinessPiece>(); //Business Piece Service
            services.AddScoped<ITheatreBusiness, TheatreBusiness>(); //Business THeatre Service
            services.AddScoped<IBusinessCatalogue, BusinessCatalogue>();
            services.AddScoped<IBusinessSiege, BusinessSiege>();
            services.AddScoped<IBusinessFavoris, BusinessFavoris>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //-------Feedback
            services.AddScoped<IFeedBackRepository, FeedbackRepository>();
            services.AddScoped<IFeedBackService, FeedBackService>();

            //------Follow
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IFollowService, FollowService>();
            //------Banner
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerService, BannerService>();
            //------Signalement------
            services.AddScoped<ISignalementRepository, SignalementRepository>();
            services.AddScoped<ISignalementService, SignalementService>();
            //------Signalement------
            services.AddScoped<ISignalementTypeRepository, SignalementTypeRepository>();

            services.AddScoped<ISignalementTypeService, SignalementTypeService>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRepostRepository, RepostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRepostBL, RepostBL>();
            services.AddScoped<IPostBL, PostBL>();
            services.AddScoped<IPublicationBL, PublicationBL>();
            return services;
        }


    }
}


