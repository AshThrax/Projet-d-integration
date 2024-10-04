namespace Blazor.UI.Data.ModelViews.Modération
{
    public class SignalementTypeDto
    {
        public string Titre { get; set; } = string.Empty;
        public string Motif { get; set; } = string.Empty;
        public bool IsPertinent { get; set; }
    }
}
