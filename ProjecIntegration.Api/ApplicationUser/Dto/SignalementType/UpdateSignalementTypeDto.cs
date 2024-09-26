namespace ApplicationUser.Dto.SignalementType
{
    public class UpdateSignalementTypeDto : UpdateUserDetailDto
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Motif { get; set; } = string.Empty;
        public bool IsPertinent { get; set; }
    }
}
