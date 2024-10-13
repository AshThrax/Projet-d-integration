using ApplicationPublication.Dto;

namespace InfraPublication.BusinessLayer
{
    public interface IRepostBL
    {
        Task CreateAsync(RepostDto pub);
        Task DeleteRePost(int repostId);
        Task<IEnumerable<RepostDto>> GetAllRePostFromPostId(int PostId);
        Task<RepostDto> GetRePostById(int repostId);
        Task UpdatePost(int repostId, RepostDto post);
    }
}