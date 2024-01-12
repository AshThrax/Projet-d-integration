using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.catalogue;
using ProjecIntegration.Api.Application.DTO.salle;

namespace ProjecIntegration.Api.Application.DTO.complexe
{
    public class AddComplexeDto: IMapFrom<Complexe>
    {
        
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<SalleDeTheatreDto> SalleDeTheatres { get; set; }
        public IList<CatalogueDto> Catalogues { get; set; }
        public AddComplexeDto()
        {
            SalleDeTheatres = new List<SalleDeTheatreDto>();
            Catalogues = new List<CatalogueDto>();
        }
        public void MappingProfile(Profile profile)
        {
           
            profile.CreateMap<AddComplexeDto, Complexe>();
        }
    }
}
