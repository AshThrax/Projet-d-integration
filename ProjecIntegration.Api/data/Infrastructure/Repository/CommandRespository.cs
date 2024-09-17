using ApplicationTheather.Common.Interfaces.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity; 

namespace dataInfraTheather.Infrastructure.Repository
{
    public class CommandRespository : Repository<Command>, ICommandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommandRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Command> AddCommand(Command command)
        {
            Command createdCommand=_dbContext.Commands.Add(command).Entity;
            await _dbContext.SaveChangesAsync();

            return createdCommand;
        }

        public async Task<IEnumerable<Command>> GetAllUserCommand(string auth0)
        {
            try
            {
                IEnumerable<Command> command = await _dbContext.Commands
                                    .Where(predicate: c => c.AuthId.Equals(auth0))
                                    .ToListAsync();
                return command;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Command> GetCommand(int id)
        {
            Command command = new();
            try
            {
                 command = await _dbContext.Commands
                            .FirstOrDefaultAsync(c => c.Id == id)
                            ?? new Command();

            }
            catch (Exception)
            {
                return command;
            
            }
            return command;
        }
        public async Task<IEnumerable<Command>> GetAllFromRepresentation(int idrepresentation)
        {
            try
            {
                IEnumerable<Command> getAllFromRepresentation = await _dbContext.Commands
                                .Where(x => x.IdRepresentation == idrepresentation)
                                .ToListAsync();
                 return getAllFromRepresentation;

            }
            catch (Exception)
            {
                return Enumerable.Empty<Command>();
            }
        }
        public async Task<IEnumerable<Command>> GetAllFromPiece(int idPiece)
        {
            try
            {
                IEnumerable<Command> getAllFromPiece = await _dbContext.Commands
                    .Where(x => x.Representation.PieceId == idPiece)
                    .ToListAsync();
                return getAllFromPiece;

            }
            catch (Exception)
            {
                return Enumerable.Empty<Command>();
            }
        }

        public async Task<bool> DoIHaveACommandForPiece(int pieceId, string userId)
        {
            try
            {
               int count = await _dbContext.Commands.Where(x => x.Representation.PieceId == pieceId && x.AuthId == userId).CountAsync();

                return (count > 0);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
