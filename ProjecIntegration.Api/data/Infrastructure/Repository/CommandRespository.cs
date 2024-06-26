﻿using ApplicationTheather.Common.Interfaces.IRepository;
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

        public void AddCommand(Command command)
        {
            _dbContext.Commands.Add(command);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Command>> GetAllUserCommand(string auth0)
        {
            var command = await _dbContext.Commands
                                .Where(c => c.AuthId.Equals(auth0))
                                .ToListAsync();
            return command;
        }

        public async Task<Command> GetCommand(int id)
        {
            var command = await _dbContext.Commands
                             
                            .FirstOrDefaultAsync(c => c.Id == id);
            return command;
        }
        public async Task<IEnumerable<Command>> GetAllFromRepresentation(int idrepresentation)
        {
            var ent = await _dbContext.Commands
                .Where(x => x.IdRepresentation == idrepresentation)
                .ToListAsync();
            return ent;
        }
        public async Task<IEnumerable<Command>> GetAllFromPiece(int idPiece)
        {
            var ent = await _dbContext.Commands
               
                .Where(x => x.Representation.IdPiece == idPiece)
                .ToListAsync();
            return ent;
        }
    }
}
