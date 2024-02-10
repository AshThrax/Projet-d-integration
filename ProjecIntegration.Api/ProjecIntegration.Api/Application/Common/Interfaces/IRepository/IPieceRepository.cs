using ProjecIntegration.Api.Models.Entity;

namespace ProjecIntegration.Api.Application.Common.Interfaces.IRepository
{
    public interface IPieceRepository : IRepository<Piece>
    {
        void AddRepresentation(int idPiece, Representation  represnetation);
        void DeleteRepresnetation(int idPiece,int idrepresentation);
        Task<IEnumerable<Piece>> GetPieceByComplexe(int idComplexe);
    }
}
