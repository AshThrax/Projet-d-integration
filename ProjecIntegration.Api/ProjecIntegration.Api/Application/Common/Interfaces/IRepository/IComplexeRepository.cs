namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface IComplexeRepository : IRepository<Complexe>
    {
        void AddSalledeTheatre(int complexeId, SalleDeTheatre salleDeTheatre);
        void DeletesalleDetheatre(int complexeId,int salleId);

        void AddCatalogue(int complexeId,Catalogue catalogue);
        
        void DeleteCatalogue(int catalogueId,int complexeid);
    }
}
