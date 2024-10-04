namespace Blazor.UI.Data.ModelViews.Modération
{
    public class SignalementDto
    {
        public string UserSignaled { get; set; } = string.Empty;
        public string UserSignaling { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsReviewedByAdmin { get; set; }
        public bool IsPertinent { get; set; }
        public int SignalementTypeId { get; set; }
        //clé Etrangére
        public SignalementTypeDto? SignalementType { get; set; }
    }
}
