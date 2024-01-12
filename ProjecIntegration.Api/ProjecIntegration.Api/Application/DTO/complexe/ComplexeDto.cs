using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.catalogue;
using ProjecIntegration.Api.Application.DTO.salle;

namespace ProjecIntegration.Api.Application.DTO.complexe
{
    public class ComplexeDto : BaseDto, IMapFrom<Complexe>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IList<SalleDeTheatreDto> SalleDeTheatres { get; set; }
        public IList<CatalogueDto> Catalogues { get; set; }
        public ComplexeDto()
        {
            SalleDeTheatres = new List<SalleDeTheatreDto>();
            Catalogues = new List<CatalogueDto>();
        }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<Complexe, ComplexeDto>();
            profile.CreateMap<ComplexeDto, Complexe>();
        }
    }
}
