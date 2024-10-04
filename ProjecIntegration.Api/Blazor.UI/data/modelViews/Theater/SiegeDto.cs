namespace Blazor.UI.Data.ModelViews.Theater
{
    public class SiegeDto :Baseview
    {
        public string Name { get; set; } = string.Empty;
        public int SalleId { get; set; }

    }
    public class AddSiegeDto
    {
        public string Name { get; set; } = string.Empty;
        public int SalleId { get; set; }
    }
    public class UpdateSiegeDto : Baseview
    {
        public string Name { get; set; } = string.Empty;
        public int SalleId { get; set; }
    }
}
