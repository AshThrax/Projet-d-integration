
namespace Blazor.UI.data.modelViews
{
    public class PostDto 
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Content { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public List<RepostDto> Repost { get; set; } = new List<RepostDto>();
    }
}
