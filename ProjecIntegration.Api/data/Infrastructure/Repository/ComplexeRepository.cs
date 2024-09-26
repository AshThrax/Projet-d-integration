using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;

namespace dataInfraTheather.Infrastructure.Repository
{
    public class ComplexeRepository : Repository<Complexe>, IComplexeRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ComplexeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }



        public async Task AddSalledeTheatre(int complexeId, SalleDeTheatre salleDeTheatre)
        {
            try
            {
                Complexe Complexe = _dbcontext.Complexe
                   .Include(x => x.SalleDeTheatres)
                   .FirstOrDefault(x => x.Id == complexeId) ?? throw new NullReferenceException("null reference s");
                if (Complexe != null)
                {
                    Complexe?.SalleDeTheatres?.Add(salleDeTheatre);
                   await _dbcontext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task DeleteSalleDetheatre(int complexeId, int salleId)
        {
            try
            {
                Complexe Complexe = _dbcontext.Complexe
                 .Include(x => x.SalleDeTheatres)
                 .FirstOrDefault(x => x.Id == complexeId) 
                 ?? throw new NullReferenceException("null refenrece");

                SalleDeTheatre salleRemoved = _dbcontext.SalleDeTheatres
                                              .FirstOrDefault(x => x.Id == salleId) 
                                              ?? throw new NullReferenceException("null refenrece");

                Complexe?.SalleDeTheatres?.Remove(salleRemoved);
               await _dbcontext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task DeletesalleDetheatre(int complexeId, int salleId)
        {
            throw new NotImplementedException();
        }
    }
}
