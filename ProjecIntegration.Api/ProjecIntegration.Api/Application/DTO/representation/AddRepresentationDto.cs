using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.catalogue;
using ProjecIntegration.Api.Application.DTO.salle;

namespace ProjecIntegration.Api.Application.DTO.representation
{
    public class AddRepresentationDto : IMapFrom<Representation>
    {
      
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Seance { get; set; }
        public CatalogueDto Catalogue { get; set; }
        public int CatalogueId { get; set; }
        public SalleDeTheatreDto SalleDeTheatre { get; set; }
        public int IdSalledeTheatre { get; set; }

        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<AddRepresentationDto, Representation>();
           
        }
    }
}
