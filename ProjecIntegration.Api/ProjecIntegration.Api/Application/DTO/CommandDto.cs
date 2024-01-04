using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;

namespace ProjecIntegration.Api.Application.DTO
{
    public class CommandDto: BaseDto, IMapFrom<Command>
    {
       
        public string Name { get; set; }
        public List<TicketsDto> CommandeTickets { get; set; }
        public UserDto User { get; set; }
        public int IdUser { get; set; }
         public CommandDto() 
         {
            CommandeTickets = new List<TicketsDto>();
         }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Command, CommandDto>();
            profile.CreateMap<CommandDto,Command>();
        }
    }
}
