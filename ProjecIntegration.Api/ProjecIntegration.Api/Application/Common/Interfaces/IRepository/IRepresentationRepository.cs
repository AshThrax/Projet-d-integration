namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface IRepresentationRepository : IRepository<Representation>
    {
        Task<IEnumerable<Representation>> GetAllBySalleId(int idSalle);
        Task<IEnumerable<Representation>> GetAllByPieceId(int idPIece);
        void AddCommandToRepresentation(int idrepresentation,Command command);
        void DeleteCommandRepresnetation(int idrepresentation,int CommandId );
    }
}
