using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO.prix
{
    public class AddPrix:IMapFrom<Prix>
    {
       
        public DateTime Added { get; set; }
        public int Price { get; set; }
        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<AddPrix, PrixDto>();
           
        }
    }
}
