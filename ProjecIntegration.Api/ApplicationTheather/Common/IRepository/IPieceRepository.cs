using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.IRepository
{
    public interface IPieceRepository : IRepository<Piece>
    {
        void AddRepresentation(int idPiece, Representation represnetation);
        void DeleteRepresnetation(int idPiece, int idrepresentation);

        Task<IEnumerable<Piece>> GetPieceByTheme(int themeId);

        Task<IEnumerable<Piece>> GetPieceByListId(List<int> pieceIds);
    }
}
