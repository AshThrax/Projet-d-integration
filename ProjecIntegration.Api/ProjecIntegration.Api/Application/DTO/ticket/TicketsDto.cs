using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.command;
using ProjecIntegration.Api.Application.DTO.prix;
using ProjecIntegration.Api.Application.DTO.representation;

namespace ProjecIntegration.Api.Application.DTO.ticket
{
    public class TicketsDto : BaseDto, IMapFrom<Ticket>
    {
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public string Name { get; set; }
        public RepresentationDto Representation { get; set; }
        public int IdRepresnentation { get; set; }
        public CommandDto Command { get; set; }
        public int CommandId { get; set; }
        public PrixDto Prix { get; set; }
        public int IdPrix { get; set; }

        public void MappingProfile(Profile profile)
        {
            profile.CreateMap<Ticket, TicketsDto>();
            profile.CreateMap<TicketsDto, Ticket>();
        }
    }
}
