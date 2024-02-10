namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface IComplexeRepository : IRepository<Complexe>
    {
        void AddSalledeTheatre(int complexeId, SalleDeTheatre salleDeTheatre);
        void DeletesalleDetheatre(int complexeId,int salleId);

        
    }
}
