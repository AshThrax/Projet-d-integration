namespace Domain.Entity.TheatherEntity
{
    public class SalleDeTheatre : BaseEntity
    {

        public string Name { get; set; }

        public int PlaceMax { get; set; }
        public int complexeId { get; set; }
        public Complexe Complexe { get; set; }

        public List<Representation> Representations { get; set; }
        public List<Piece> Pieces { get; set; }

    }
}
