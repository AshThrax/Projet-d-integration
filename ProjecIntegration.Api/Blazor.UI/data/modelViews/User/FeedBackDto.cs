namespace Blazor.UI.Data.ModelViews.User
{
    public class FeedBackDto:Baseview
    {
        public string Description { get; set; } = string.Empty;
        public int Evalutation { get; set; }
        public string Titre { get; set; } = string.Empty;
    }
    public class AddFeedBackDto
    {
        public string Description { get; set; } = string.Empty;
        public int Evalutation { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
    public class UpdateFeedBackDto:Baseview
    {
        public string Description { get; set; } = string.Empty;
        public int Evalutation { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
