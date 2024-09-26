using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfraTheather.Infrastructure.Repository
{
    public class CataloguePieceRepository : Repository<CataloguePiece>, ICataloguePieceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CataloguePieceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<int>> GetPieceFromCatalogue(int catalogueId)
        {
            try
            {
                IEnumerable<CataloguePiece> cataloguePieces = await _dbContext.CataloguePiece
                                                                              .Where(c =>c.CatalogueId == catalogueId)
                                                                              .ToListAsync();
               
                IEnumerable<int> getPieceIds =cataloguePieces.Select(c => c.PieceId).ToList();

                return getPieceIds ?? new List<int>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Catalogue?>> GetCatalogueFromPieceId(int pieceId)
        {
            try
            {
                IEnumerable<CataloguePiece> cataloguePieces = await _dbContext.CataloguePiece
                                                                              .Where(c => c.PieceId == pieceId)
                                                                              .ToListAsync();

                IEnumerable<Catalogue?> getCatalogue = cataloguePieces.Select(c => c.Catalogue).ToList();

                return getCatalogue ?? new List<Catalogue?>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemovePieceFromcatalogue(int cataloguePieceId)
        {
            try
            {
                CataloguePiece entity =await _dbContext.CataloguePiece.FirstOrDefaultAsync(x=>x.Id == cataloguePieceId) ?? throw new NullReferenceException();

                if (entity != null)
                {
                    _dbContext.CataloguePiece.Remove(entity);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CataloguePiece> GetCataloguePiece(int catalogueId, int pieceId)
        {
            try
            {
               return await _dbContext.CataloguePiece.FirstOrDefaultAsync(x => x.CatalogueId == catalogueId && x.PieceId == pieceId) ?? new CataloguePiece();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemovePieceFromcatalogue(int catalogueId, int pieceId)
        {
            try
            {

                CataloguePiece entity = await _dbContext.CataloguePiece.FirstOrDefaultAsync(x =>x.CatalogueId==catalogueId && x.PieceId==pieceId) ?? throw new NullReferenceException();

                if (entity != null)
                {
                    _dbContext.CataloguePiece.Remove(entity);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
