using ApplicationTheather.DTO;
using Domain.DataType;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessFavoris
    {
        Task<ServiceResponse<FavorisDto>> CreateFavoris(string userId);
        Task<Pagination<PieceDto>> PaginateFavoris(string userId, int page);
        Task<ServiceResponse<FavorisDto>> AddToFavoris(int favorisId, int pieceId);
        Task<ServiceResponse<FavorisDto>> AddToFavoris(string userId, int pieceId);
        Task<ServiceResponse<FavorisDto>> DeleteFromFavoris(int favorisId, int pieceid);
    }
}
