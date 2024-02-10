namespace data.Infrastructure.Repository
{
    public class SalleDeTheatreRepository : Repository<SalleDeTheatre>, ISalleDeTheatreRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public SalleDeTheatreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public void AddPieceToSalle(int idSalle, Piece piece)
        {
            var salleDetheatre = _dbcontext.SalleDeTheatres.SingleOrDefault(r => r.Id == idSalle);
            if (salleDetheatre != null)
            {
                salleDetheatre.Pieces.Add(piece);
                _dbcontext.SaveChanges();
            }
        }

        public void AddRepresentationToSalle(int Idsalle, Representation Addrepresentation)
        {
            var salleDetheatre= _dbcontext.SalleDeTheatres.FirstOrDefault(r=>r.Id==Idsalle);
            if (salleDetheatre != null)
            {
                salleDetheatre.Representations.Add(Addrepresentation);
                _dbcontext.SaveChanges();
            }
        }

        public void DeletePieceToSalle(int idSalle, int idPiece)
        {
            var salleDetheatre = _dbcontext.SalleDeTheatres.SingleOrDefault(r => r.Id == idSalle);
            if (salleDetheatre != null)
            {
                var PieceToDelete=salleDetheatre.Pieces.FirstOrDefault(r => r.Id == idPiece);
                if (PieceToDelete !=null)
                {
                    salleDetheatre.Pieces.Remove(PieceToDelete);
                    _dbcontext.SaveChanges();
                }
                _dbcontext.SaveChanges();
            }
        }

        public void DeleteRepresentationToSalle(int Idsalle, int idRepresentation)
        {
            var salleDetheatre = _dbcontext.SalleDeTheatres.FirstOrDefault(r => r.Id == Idsalle);

            if (salleDetheatre != null)
            {
                var commandToDelete = salleDetheatre.Representations.FirstOrDefault(c => c.Id == idRepresentation);

                if (commandToDelete != null)
                {
                    salleDetheatre.Representations.Remove(commandToDelete);
                    _dbcontext.SaveChanges();
                }
            }
        }
        public async Task<IEnumerable<SalleDeTheatre>> GetByIdComplexe(int idComplexe)
        {
            var sallebyComplexe= await _dbcontext.SalleDeTheatres
                .Include(c=>c.Pieces)
                .Where(c =>c.complexeId==idComplexe)
                .ToListAsync();
            return sallebyComplexe;
        }
    }
}
