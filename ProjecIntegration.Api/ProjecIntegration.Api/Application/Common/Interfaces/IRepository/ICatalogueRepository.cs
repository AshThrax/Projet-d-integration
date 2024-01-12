namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface ICatalogueRepository : IRepository<Catalogue>
    {
        void AddRepresentation(int catalogueid,Representation represnetation);
        void DeleteRepresentation(int catalogueid, int represenatationid);
    }
}
