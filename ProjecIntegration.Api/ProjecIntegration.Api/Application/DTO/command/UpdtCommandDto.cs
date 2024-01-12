using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.ticket;

namespace ProjecIntegration.Api.Application.DTO.command
{
    public class UpdtCommandDto:IMapFrom<Command>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public List<TicketsDto> CommandeTickets { get; set; }
        public string AuthId { get; set; }
        public int IdUser { get; set; }
        public UpdtCommandDto()
        {
            CommandeTickets = new List<TicketsDto>();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdtCommandDto,Command>();
        }
    }
}
