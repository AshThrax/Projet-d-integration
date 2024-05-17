namespace Blazor.UI.data.modelViews
{
    public class PublicationDto 
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public int PieceId { get; set; }
        public ICollection<string> post { get; set; } = new List<string>();
    }
    public class AddPublicationDto
    {

        public string Title { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public int PieceId { get; set; }
        public ICollection<string> post { get; set; } = new List<string>();
    }
    public class UpdatePublicationDto 
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public int PieceId { get; set; }
        public string UserId { get; set; } = string.Empty;

        public ICollection<string> post { get; set; } = new List<string>();
    }
}
