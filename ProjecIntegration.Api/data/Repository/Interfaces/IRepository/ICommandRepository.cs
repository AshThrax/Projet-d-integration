
namespace data.Interfaces.IRepository
{
    public interface ICommandRepository : IRepository<Command>
    {
        Task<Command> GetCommand(int id);
        void AddCommand(Command command);
        Task<IEnumerable<Command>> GetAllUserCommand(string auth0);
        Task<IEnumerable<Command>> GetAllFromPiece(int idPiece);
        Task<IEnumerable<Command>> GetAllFromRepresentation(int idRepresentation);
    }
}
