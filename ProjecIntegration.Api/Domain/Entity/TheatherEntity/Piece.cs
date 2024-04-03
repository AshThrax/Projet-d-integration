namespace Domain.Entity.TheatherEntity
{
    public class Piece : BaseEntity
    {
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public List<Representation> Representations { get; set; }
        public int IdSalle { get; set; }
        public SalleDeTheatre SalleDeTheatre { get; set; }

    }
}
