using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //-----------------------------------------
            CreateMap<CommandDto, Command>();
            CreateMap<AddCommandDto, Command>();
            CreateMap<UpdateCommandDto, Command>();
            CreateMap<Command, CommandDto>();
            //-----------------------------------------
            CreateMap<ComplexeDto, Complexe>();
            CreateMap<AddComplexeDto, Complexe>();
            CreateMap<UpdateComplexeDto, Complexe>();
            CreateMap<Complexe, ComplexeDto>();
            //-----------------------------------------
            //CreateMap<Entreprise, EntrepriseDto>();
            // CreateMap<EntrepriseDto, Entreprise>();
            //-----------------------------------------
            CreateMap<Piece, PieceDto>();
            CreateMap<AddPieceDto, Piece>();
            CreateMap<UpdatePieceDto, Piece>();
            CreateMap<PieceDto, Piece>();
            //-----------------------------------------
            CreateMap<Representation, RepresentationDto>();
            CreateMap<AddRepresentationDto, Representation>();
            CreateMap<UpdateRepresentationDto, Representation>();
            CreateMap<RepresentationDto, RepresentationDto>();
            //-----------------------------------------
            CreateMap<SalleDeTheatre, SalleDeTheatreDto>();
            CreateMap<AddSalleDeTheatreDto, SalleDeTheatre>();
            CreateMap<UpdateSalleDeTheatreDto, SalleDeTheatre>();
            CreateMap<SalleDeTheatreDto, SalleDeTheatre>();
            //-------------------------------------------
            CreateMap<Theme,ThemeDto>().ReverseMap();
            CreateMap<Catalogue, CatalogueDto>().ReverseMap();
        }
    }
}
