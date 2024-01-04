using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO
{
    public class CatalogueDto :BaseDto, IMapFrom<Catalogue>
    {
        

        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RepresentationDto> Representations { get; set; }
        public ComplexeDto Complexe { get; set; }
        public int ComplexeId { get; set; }
        public DateTime DebutCatalogue { get; set; }

        public DateTime FinCatalogue { get; set; }

        public CatalogueDto() {
            Representations = new List<RepresentationDto>();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Catalogue,CatalogueDto>();
            profile.CreateMap<CatalogueDto,Catalogue>();
        }
    }
}
