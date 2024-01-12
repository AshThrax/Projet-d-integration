
namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface ICommandRepository : IRepository<Command>
    {
        Task<Command> GetCommand(int id);
        void AddCommand(Command command);
        void AddTicketToCommand(int commandId,Ticket ticket);
        Task<IEnumerable<Command>> GetAllUserCommand();
    }
}
