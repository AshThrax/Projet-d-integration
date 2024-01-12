using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.complexe;

namespace ProjecIntegration.Api.Application.DTO.entreprise
{
    public class AddEntrepriseDto: IMapFrom<Entreprise>
    {
        public string Nom { get; set; }
        public string Adress { get; set; }
        public IList<ComplexeDto> Complexes { get; set; }
        public AddEntrepriseDto()
        {
            Complexes = new List<ComplexeDto>();
        }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<AddEntrepriseDto, Entreprise>();
        }
    }
}
