using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.complexe;
using ProjecIntegration.Api.Application.DTO.representation;

namespace ProjecIntegration.Api.Application.DTO.salle
{
    public class SalleDeTheatreDto : BaseDto, IMapFrom<SalleDeTheatre>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public string Name { get; set; }

        public int PlaceMax { get; set; }

        public int PlaceCurrent { get; set; }
        public IList<RepresentationDto> Representations { get; set; }

        public ComplexeDto Complexe { get; set; }
        public int ComplexeId { get; set; }
        public SalleDeTheatreDto()
        {
            Representations = new List<RepresentationDto>();
        }

        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<SalleDeTheatre, SalleDeTheatreDto>();
            profile.CreateMap<SalleDeTheatreDto, SalleDeTheatre>();
        }
    }
}
