namespace ApplicationUser.Dto.SignalementType
{
    public class AddSignalementTypeDto :AddBaseDto
    {
        public string Titre { get; set; } = string.Empty;
        public string Motif { get; set; } = string.Empty;
        public bool IsPertinent { get; set; }
    }
}
