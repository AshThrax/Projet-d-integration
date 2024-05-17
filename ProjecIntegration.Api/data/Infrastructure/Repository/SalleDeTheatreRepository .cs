using ApplicationTheather.Common.Interfaces.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;
namespace dataInfraTheather.Infrastructure.Repository
{
    public class SalleDeTheatreRepository : Repository<SalleDeTheatre>, ISalleDeTheatreRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public SalleDeTheatreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

       

        public void AddRepresentationToSalle(int Idsalle, Representation Addrepresentation)
        {
            try
            {
                SalleDeTheatre salleDetheatre = _dbcontext.SalleDeTheatres.FirstOrDefault(r => r.Id == Idsalle) ?? throw new NullReferenceException("null reference ");
                if (salleDetheatre != null)
                {
                    salleDetheatre.Representations?.Add(Addrepresentation);
                    _dbcontext.SaveChanges();
                }

            }
            catch (Exception)
            {

            }
        }


        public void DeleteRepresentationToSalle(int Idsalle, int idRepresentation)
        {
            try
            {
                SalleDeTheatre salleDetheatre = _dbcontext.SalleDeTheatres.FirstOrDefault(r => r.Id == Idsalle) 
                                                        ?? throw new NullReferenceException("Null references"); ;

                if (salleDetheatre != null)
                {
                    Representation RepresentationToDelete = salleDetheatre?.Representations?.FirstOrDefault(c => c.Id == idRepresentation) 
                                                                ?? throw new NullReferenceException("Null references");

                    if (RepresentationToDelete != null)
                    {
                        salleDetheatre.Representations.Remove(RepresentationToDelete);
                        _dbcontext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public async Task<IEnumerable<SalleDeTheatre>> GetByIdComplexe(int idComplexe)
        {
            try
            {
                IEnumerable<SalleDeTheatre> sallebyComplexe = await _dbcontext.SalleDeTheatres
                    .Include(c => c.Representations)
                    .Where(c => c.ComplexeId == idComplexe)
                    .ToListAsync();
                return sallebyComplexe;

            }
            catch (Exception)
            {

                return Enumerable.Empty<SalleDeTheatre>();
            }
        }
    }
}
