namespace Blazor.UI.Data.ModelViews.Publication;

public class PostDto
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string PublicationId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    //public List<RepostDto> Repost { get; set; } = new List<RepostDto>();
}
public class AddPostDto
{
    public string Content { get; set; } = string.Empty;
    public string PublicationId { get; set; } = string.Empty;
}