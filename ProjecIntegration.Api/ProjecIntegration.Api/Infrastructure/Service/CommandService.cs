using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    public class CommandService : GeneriqueService<Command, CommandDto>, ICommandService
    {
        public CommandService(IRepository<Command> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
