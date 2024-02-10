namespace data.Infrastructure.Repository
{
    public class RepresentationRespository : Repository<Representation>, IRepresentationRepository
    {
        private readonly ApplicationDbContext _context;

        public RepresentationRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void AddCommandToRepresentation(int idRepresentation, Command command)
        {
            var representation = _context.Representations.FirstOrDefault(r => r.Id == idRepresentation);

            if (representation != null)
            {
                if (representation.Commands == null)
                {
                    representation.Commands = new List<Command>();

                }
                //chaque fois qu'on ajoute une commande le nombre de place diminiue
                var place = command.Tickets.Count;
                representation.placeCurrent=representation.placeCurrent+place;
                representation.Commands.Add(command);
                _context.SaveChanges();
            }
        }

        public void DeleteCommandRepresnetation(int idrepresentation, int CommandId)
        {
            var representation = _context.Representations
                .FirstOrDefault(r => r.Id == idrepresentation);
            
            if (representation != null)
            {

                var Commanddelete = representation
                    .Commands.FirstOrDefault(r => r.Id == CommandId);

                //chaque fois qu'on supprime une commande le nombre de place dispo pour la reservation augmente
                var place =Commanddelete.Tickets.Count;
                representation.placeCurrent=representation.placeCurrent-place;
                representation.Commands.Remove(Commanddelete) ;
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Representation>> GetAllByPieceId(int idPIece)
        {
           var piece= _context.Pieces.Include(c =>c.Representations)
               .Where(c => c.Id == idPIece)
                .FirstOrDefault();
            if (piece != null)
            {
                var result = piece.Representations;
                return result;
            }

            return null; 
        }
        public async Task<IEnumerable<Representation>> GetAllBySalleId(int idSalle)
        {
            var salle= await _context.SalleDeTheatres
                .Include(c =>c.Representations)
                .Where(c =>c.Id==idSalle)
                .FirstOrDefaultAsync();

            var Entities = salle.Representations;
            return Entities;
        }
    }
}
