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
            try
            {
                Piece piece = _context.Pieces.FirstOrDefault(x => x.Id == idPiece) ?? throw new NullReferenceException("reference null");
                if (piece != null)
                {
                    piece.Representations ??= new List<Representation>();
                    piece.Representations.Add(represnetation);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteRepresnetation(int idPiece, int idrepresentation)
        {
            try
            {
                Piece piece = _context.Pieces.FirstOrDefault(x => x.Id == idPiece) ?? throw new NullReferenceException("reference null");
                if (piece != null)
                {
                    Representation representationDelete = piece?.Representations?.FirstOrDefault(cx => cx.Id == idrepresentation)
                                                           ?? throw new NullReferenceException(" null reference exception");
                    piece.Representations.Remove(representationDelete);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Piece>> GetPieceByListId(List<int> pieceIds)
        {
            try
            {
                return await _context.Pieces.Include(x => x.Image).Where(x => pieceIds.Contains(x.Id)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Piece>> GetPieceByTheme(int themeId)
        {
            try
            {
                IEnumerable<Piece> getPiece= await _context.Pieces.Include(x => x.Image).Where(x=>x.ThemeId == themeId).ToListAsync();

                return getPiece;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Piece>();
           
            }
        }
    }
}
