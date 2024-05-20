using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface ISalleDeTheatreRepository : IRepository<SalleDeTheatre>
    {
        Task AddRepresentationToSalle(int Idsalle, Representation Addrepresentation);
        Task DeleteRepresentationToSalle(int Idsalle, int idRepresentation);

        Task<IEnumerable<SalleDeTheatre>> GetByIdComplexe(int idComplexe);

     
    }
}
