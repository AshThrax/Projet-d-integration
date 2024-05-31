namespace Blazor.UI.Data.modelViews;

public class Baseview
{
    public int Id { get; set; }
    public DateTime AddedTime { get; set; } = DateTime.Now;
}

public class MongoView
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
}