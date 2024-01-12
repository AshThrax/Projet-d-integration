using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO.prix
{
    public class PrixDto : BaseDto, IMapFrom<Prix>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public int Price { get; set; }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<Prix, PrixDto>();
            profile.CreateMap<PrixDto, Prix>();
        }
    }
}
