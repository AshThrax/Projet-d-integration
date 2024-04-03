namespace Domain.Entity.TheatherEntity
{
    public class Representation : BaseEntity
    {


        public int Prix { get; set; }
        public DateTime Seance { get; set; }
        public int PlaceMaximum { get; set; }
        public int placeCurrent { get; set; }
        //------salle de theatre
        public SalleDeTheatre SalleDeTheatre { get; set; }
        public int IdSalledeTheatre { get; set; }
        public Piece Piece { get; set; }
        public int IdPiece { get; set; }
        //-----commande/reservation
        public List<Command> Commands { get; set; }
    }
}
