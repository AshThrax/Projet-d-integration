using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface ICommandRepository : IRepository<Command>
    {
        Task<Command> GetCommand(int id);
        Task AddCommand(Command command);
        Task<IEnumerable<Command>> GetAllUserCommand(string auth0);
        Task<IEnumerable<Command>> GetAllFromPiece(int idPiece);
        Task<IEnumerable<Command>> GetAllFromRepresentation(int idRepresentation);
    }
}
