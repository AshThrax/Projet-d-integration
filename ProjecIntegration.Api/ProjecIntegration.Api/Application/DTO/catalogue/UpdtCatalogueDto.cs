using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.complexe;
using ProjecIntegration.Api.Application.DTO.representation;

namespace ProjecIntegration.Api.Application.DTO.catalogue
{
    public class UpdtCatalogueDto : IMapFrom<Catalogue>
    {

        public int Id { get; set; }
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RepresentationDto> Representations { get; set; }
        public ComplexeDto Complexe { get; set; }
        public int ComplexeId { get; set; }
        public DateTime DebutCatalogue { get; set; }

        public DateTime FinCatalogue { get; set; }

        public UpdtCatalogueDto()
        {
            Representations = new List<RepresentationDto>();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Catalogue, CatalogueDto>();
            profile.CreateMap<CatalogueDto, Catalogue>();
        }
    }
}
