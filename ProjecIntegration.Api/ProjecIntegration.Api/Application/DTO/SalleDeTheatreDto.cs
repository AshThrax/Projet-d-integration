using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO
{
    public class SalleDeTheatreDto : BaseDto, IMapFrom<SalleDeTheatre>
    {
       
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
