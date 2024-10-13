using ApplicationTheater.Common;
using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.IRepository
{
    public interface ICommandRepository : IRepository<Command>
    {
        Task<Command> GetCommand(int id);
        Task<Command> AddCommand(Command command);
        Task<bool> DoIHaveACommandForPiece(int pieceId, string userId);
        Task<IEnumerable<Command>> GetAllUserCommand(string auth0);
        Task<IEnumerable<Command>> GetAllFromPiece(int idPiece);
        Task<IEnumerable<Command>> GetAllFromRepresentation(int idRepresentation);

    }
}
