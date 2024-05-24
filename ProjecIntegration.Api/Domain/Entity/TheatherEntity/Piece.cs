

namespace Domain.Entity.TheatherEntity
{
    public class Piece : BaseEntity
    {
        public string Titre { get; set; } =string.Empty;
        public int Duree { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public List<Representation>? Representations { get; set; }
        public int ImageId { get; set; }
        public Image? Image { get; set; }
        public int ThemeId { get; set; }
        public Theme? Theme { get; set; }

    }
}
