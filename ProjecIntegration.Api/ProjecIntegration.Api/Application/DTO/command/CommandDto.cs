using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.ticket;

namespace ProjecIntegration.Api.Application.DTO.command
{
    public class CommandDto : BaseDto, IMapFrom<Command>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public List<TicketsDto> CommandeTickets { get; set; }
        public string AuthId { get; set; }
        public int IdUser { get; set; }
        public CommandDto()
        {
            CommandeTickets = new List<TicketsDto>();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Command, CommandDto>();
            profile.CreateMap<CommandDto, Command>();
        }
    }
}
