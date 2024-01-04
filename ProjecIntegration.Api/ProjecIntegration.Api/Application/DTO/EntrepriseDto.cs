using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO
{
    public class EntrepriseDto: BaseDto, IMapFrom<Entreprise>
    {
      
        public string Nom { get; set; }
        public string Adress { get; set; }
        public IList<ComplexeDto> Complexes { get; set; } 
        public EntrepriseDto() 
        { 
            Complexes= new List<ComplexeDto>();
        }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<Entreprise, EntrepriseDto>();
        }
    }
}
