using ApplicationPublication.Dto;
using Domain.ServiceResponse;

namespace InfraPublication.BusinessLayer
{
    public interface IPublicationBL
    {
        Task<ServiceResponse<PublicationDto>> CreatePublication(AddPublicationDto pub);
        Task<ServiceResponse<PublicationDto>> DeletePublication(int pubId);
        Task<ServiceResponse<IEnumerable<PublicationDto>>> GetAllbyPublicationByUserId(string userId);
        Task<ServiceResponse<IEnumerable<PublicationDto>>> GetAllPublication();
        Task<ServiceResponse<PublicationDto>> GetPublicationById(int pubId);
        Task<ServiceResponse<IEnumerable<PublicationDto>>> GetPublicationByPiece(int pieceId);
        Task<bool> Hasreview(int pieceId, string userId);
        Task<bool> IsAuthor(int pubId, string userId);
        Task<ServiceResponse<PublicationDto>> UpdatePublication(int pubId, string title, string content);
    }
}