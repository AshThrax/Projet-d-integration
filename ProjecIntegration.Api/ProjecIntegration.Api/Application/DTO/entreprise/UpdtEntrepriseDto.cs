using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.complexe;

namespace ProjecIntegration.Api.Application.DTO.entreprise
{
    public class UpdtEntrepriseDto :IMapFrom<Entreprise>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public string Nom { get; set; }
        public string Adress { get; set; }
        public IList<ComplexeDto> Complexes { get; set; }
        public UpdtEntrepriseDto()
        {
            Complexes = new List<ComplexeDto>();
        }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<UpdtEntrepriseDto, Entreprise>();
        }
    }
}
