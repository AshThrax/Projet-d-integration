namespace ApplicationUser.Dto.Signalement
{
    public class UpdateSignalementDto:UpdateUserDetailDto
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserSignaled { get; set; } = string.Empty;
        public string UserSignaling { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsReviewedByAdmin { get; set; }
        public bool IsPertinent { get; set; }
        public int SignalementTypeId { get; set; }
        public int UserDetailsId { get; set; }
    }
}
