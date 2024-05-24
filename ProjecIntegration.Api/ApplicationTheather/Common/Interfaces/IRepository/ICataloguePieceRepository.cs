using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface ICataloguePieceRepository : IRepository<CataloguePiece>
    {
        Task<IEnumerable<int>> GetPieceFromCatalogue(int pieceId);

        Task<IEnumerable<Catalogue?>> GetCatalogueFromPieceId(int catalogueId);

        Task RemovePieceFromcatalogue(int catalogueId, int pieceId);

        Task<CataloguePiece> GetCataloguePiece(int catalogueId, int pieceId);

    }
}
