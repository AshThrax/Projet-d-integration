using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO
{
    public class PrixDto : BaseDto, IMapFrom<Prix>
    {
        public int Price { get; set; }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<Prix, PrixDto>();
            profile.CreateMap<PrixDto, Prix>();
        }
    }
}
