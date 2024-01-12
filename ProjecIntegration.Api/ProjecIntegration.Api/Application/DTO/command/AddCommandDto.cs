using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.ticket;

namespace ProjecIntegration.Api.Application.DTO.command
{
    public class AddCommandDto :IMapFrom<Command>
    {
    
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public List<TicketsDto> CommandeTickets { get; set; }
        public string AuthId { get; set; }
        public int IdUser { get; set; }
        public AddCommandDto()
        {
            CommandeTickets = new List<TicketsDto>();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddCommandDto,Command>();
        }

    }
}
