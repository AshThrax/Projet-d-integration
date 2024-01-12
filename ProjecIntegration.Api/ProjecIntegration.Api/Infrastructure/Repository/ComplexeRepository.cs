using Microsoft.EntityFrameworkCore;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class ComplexeRepository : Repository<Complexe>, IComplexeRepository
    {
        private readonly ApplicationDbContext _Dbcontext;
        public ComplexeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Dbcontext = dbContext;
        }

        public void AddCatalogue(int complexeId, Catalogue catalogue)
        {
           var Complexe =_Dbcontext.Complexe
                .Include(x => x.Catalogues)
                .FirstOrDefault(x =>x.Id == complexeId);
            if (Complexe != null)
            {
                Complexe.Catalogues.Add(catalogue);
                _Dbcontext.SaveChanges();
            }
        }

        public void AddSalledeTheatre(int complexeId, SalleDeTheatre salleDeTheatre)
        {
            var Complexe = _Dbcontext.Complexe
               .Include(x => x.SalleDeTheatres)
               .FirstOrDefault(x => x.Id == complexeId);
            if (Complexe != null)
            {
                Complexe.SalleDeTheatres.Add(salleDeTheatre);
                _Dbcontext.SaveChanges();
            }
        }

        public void DeleteCatalogue(int catalogueId, int complexeId)
        {
            var Complexe = _Dbcontext.Complexe
               .Include(x => x.Catalogues)
               .FirstOrDefault(x => x.Id == complexeId);

            var cataloguerRemoved = _Dbcontext.Catalogues.FirstOrDefault(x => x.Id == complexeId);

            Complexe.Catalogues.Remove(cataloguerRemoved);
            _Dbcontext.SaveChanges();
        }

        public void DeletesalleDetheatre(int complexeId, int salleId)
        {
            var Complexe = _Dbcontext.Complexe
             .Include(x => x.SalleDeTheatres)
             .FirstOrDefault(x => x.Id == complexeId);

            var salleRemoved=_Dbcontext.SalleDeTheatres.FirstOrDefault(x => x.Id == salleId);

            Complexe.SalleDeTheatres.Remove(salleRemoved);
            _Dbcontext.SaveChanges();
        }
    }
}
