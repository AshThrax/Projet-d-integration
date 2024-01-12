using Microsoft.EntityFrameworkCore;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class CommandRespository : Repository<Command>, ICommandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommandRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCommand(Command command)
        {
           _dbContext.Commands.Add(command);
            _dbContext.SaveChanges();
        }

        public void AddTicketToCommand(int commandId, Ticket ticket)
        {
            var command =_dbContext.Commands
                .Include(c => c.Tickets)
                .FirstOrDefault(c =>c.Id == commandId);
            if(command == null) 
            {
                command.Tickets.Add(ticket);
                _dbContext.SaveChanges() ;
            }
        }

        public async Task<IEnumerable<Command>> GetAllUserCommand(string auth0)
        {
            var command = await _dbContext.Commands
            .Include(c => c.Tickets)
               .Where(c => c.AuthId==auth0)
               .ToListAsync();
            return command;
        }
      
        public async Task<Command> GetCommand(int id)
        {
            var command = await  _dbContext.Commands
                .Include(c => c.Tickets)
                .FirstOrDefaultAsync(c => c.Id == id);
            return command;
        }
    }
}
