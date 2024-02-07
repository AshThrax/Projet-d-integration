/*
namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class EntrepriseReposiotry : Repository<Entreprise>, IEntrepriseRepository
    {
        private readonly ApplicationDbContext _context;
        public EntrepriseReposiotry(ApplicationDbContext dbContext) : base(dbContext)
        {   
            _context = dbContext;
        }

        public void AddComplexeToEntreprise(int idEnterprise, Complexe complexe)
        {
            var Ent = _context.Entreprises.FirstOrDefault(e => e.Id == idEnterprise);
            if (Ent == null)
            {
               Ent.Complexes.Add( complexe );
               _context.SaveChanges();
            }
        }

        public void DeleteComplexe(int idEnterprise, int idComplexe)
        {
            var Ent = _context.Entreprises.FirstOrDefault(e => e.Id == idEnterprise);
            if (Ent == null)
            {
                var DelComp= Ent.Complexes.FirstOrDefault(e => e.Id == idComplexe);
                Ent.Complexes.Remove(DelComp);
                _context.SaveChanges();
            }
        }
    }
}
*/