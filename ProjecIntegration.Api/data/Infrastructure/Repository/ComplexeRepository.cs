using ApplicationTheather.Common.Interfaces.IRepository;
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



        public void AddSalledeTheatre(int complexeId, SalleDeTheatre salleDeTheatre)
        {
            var Complexe = _dbcontext.Complexe
               .Include(x => x.SalleDeTheatres)
               .FirstOrDefault(x => x.Id == complexeId);
            if (Complexe != null)
            {
                Complexe.SalleDeTheatres.Add(salleDeTheatre);
                _dbcontext.SaveChanges();
            }
        }


        public void DeletesalleDetheatre(int complexeId, int salleId)
        {
            var Complexe = _dbcontext.Complexe
             .Include(x => x.SalleDeTheatres)
             .FirstOrDefault(x => x.Id == complexeId);

            var salleRemoved = _dbcontext.SalleDeTheatres.FirstOrDefault(x => x.Id == salleId);

            Complexe.SalleDeTheatres.Remove(salleRemoved);
            _dbcontext.SaveChanges();
        }
    }
}
