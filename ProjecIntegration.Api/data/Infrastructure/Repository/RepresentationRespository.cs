using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;

namespace dataInfraTheather.Infrastructure.Repository
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
            try
            {
                Representation representation = _context.Representations.FirstOrDefault(r => r.Id == idRepresentation) ?? new Representation();

                if (representation != null)
                {
                    if (representation.Commands == null)
                    {
                        representation.Commands = new List<Command>();

                    }
                    //chaque fois qu'on ajoute une commande le nombre de place diminiue
                    int place = command.NombreDePlace;
                    if ((representation.PlaceCurrent + place) < representation.PlaceMaximum)
                    {
                        representation.PlaceCurrent += +place;
                        representation.Commands.Add(command);
                    }


                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async void DeleteCommandRepresnetation(int idrepresentation, int CommandId)
        {
            try
            {
                Representation representation = _context.Representations
                    .FirstOrDefault(r => r.Id == idrepresentation) ?? throw new NullReferenceException("null references"); ;

                if (representation != null)
                {

                    Command Commanddelete = representation
                        .Commands?.FirstOrDefault(r => r.Id == CommandId) 
                        ?? throw new NullReferenceException("null references");

                    //chaque fois qu'on supprime une commande le nombre de place dispo pour la reservation augmente
                    int place = Commanddelete.NombreDePlace;
                    representation.PlaceCurrent -=  - place;
                    representation.Commands.Remove(Commanddelete);
                   await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Representation>> GetAllByPieceId(int idPIece)
        {
            try
            {
                Piece piece =await _context.Pieces.Include(c => c.Representations)
                     .FirstOrDefaultAsync(c => c.Id == idPIece) ?? throw new NullReferenceException("null references"); ;
                if (piece != null)
                {
                    IEnumerable<Representation> result = piece.Representations 
                                                         ?? new List<Representation>();
                    return result;
                }

                return new List<Representation>();
                
            }
            catch (Exception )
            {
                return new List<Representation>();

            }
        }
        public async Task<IEnumerable<Representation>> GetAllBySalleId(int idSalle)
        {
            try
            {
                SalleDeTheatre salle = await _context.SalleDeTheatres
                    .Include(c => c.Representations)
                    .Where(c => c.Id == idSalle)
                    .FirstOrDefaultAsync() 
                    ?? throw new NullReferenceException();


                if (salle?.Representations != null)
                {
                    var Entities = salle.Representations;
                    return Entities;
                }
                return Enumerable.Empty<Representation>();

            }
            catch (Exception)
            {
                return Enumerable.Empty<Representation>();
                throw;
            }
        }
    }
}
