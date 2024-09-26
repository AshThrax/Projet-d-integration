using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
namespace dataInfraTheather.Infrastructure.Repository
{
    public class SalleDeTheatreRepository : Repository<SalleDeTheatre>, ISalleDeTheatreRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SalleDeTheatreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task AddRepresentationToSalle(int Idsalle, Representation Addrepresentation)
        {
            try
            {
                SalleDeTheatre salleDetheatre = _dbContext.SalleDeTheatres.FirstOrDefault(r => r.Id == Idsalle) ?? throw new NullReferenceException("null reference ");
                if (salleDetheatre != null)
                {
                    salleDetheatre.Representations?.Add(Addrepresentation);
                    await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

            }
        }


        public async Task DeleteRepresentationToSalle(int Idsalle, int idRepresentation)
        {
            try
            {
                SalleDeTheatre salleDetheatre = _dbContext.SalleDeTheatres.FirstOrDefault(r => r.Id == Idsalle) 
                                                        ?? throw new NullReferenceException("Null references"); ;

                if (salleDetheatre != null)
                {
                    Representation RepresentationToDelete = salleDetheatre?.Representations?.FirstOrDefault(c => c.Id == idRepresentation) 
                                                                ?? throw new NullReferenceException("Null references");

                    if (RepresentationToDelete != null)
                    {
                        salleDetheatre.Representations.Remove(RepresentationToDelete);
                        await _dbContext.SaveChangesAsync();
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
                IEnumerable<SalleDeTheatre> sallebyComplexe = await _dbContext.SalleDeTheatres
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
