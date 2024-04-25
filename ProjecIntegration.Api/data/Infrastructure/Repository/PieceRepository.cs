using ApplicationTheather.Common.Interfaces.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;

namespace dataInfraTheather.Infrastructure.Repository
{
    public class PieceRepository : Repository<Piece>, IPieceRepository
    {
        private readonly ApplicationDbContext _context;
        public PieceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void AddRepresentation(int idPiece, Representation represnetation)
        {
            var piece = _context.Pieces.FirstOrDefault(x => x.Id == idPiece);
            if (piece != null)
            {
                if (piece.Representations == null)
                {
                    piece.Representations = new List<Representation>();
                }
                piece.Representations.Add(represnetation);
                _context.SaveChanges();
            }
        }

        public void DeleteRepresnetation(int idPiece, int idrepresentation)
        {
            var piece = _context.Pieces.FirstOrDefault(x => x.Id == idPiece);
            if (piece != null)
            {
                var representationDelete = piece.Representations.FirstOrDefault(cx => cx.Id == idrepresentation);
                piece.Representations.Remove(representationDelete);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Piece>> GetPieceByComplexe(int idComplexe)
        {


            //------
            var salle = await _context.SalleDeTheatres
                .Include(c => c.Pieces)
                .Where(c => c.complexeId == idComplexe).ToListAsync();

            IList<Piece> pieces = new List<Piece>();
            foreach (var item in salle)
            {
                foreach (Piece play in item.Pieces)
                {
                    pieces.Add(play);

                }
            }

            return pieces.AsEnumerable();
        }

    }
}
