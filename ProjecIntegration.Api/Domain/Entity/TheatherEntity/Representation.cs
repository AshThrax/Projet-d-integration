using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.TheatherEntity
{
    public class Representation : BaseEntity
    {


        public int Prix { get; set; }
        public DateTime Seance { get; set; }
        public int PlaceMaximum { get; set; }
        public int PlaceCurrent { get; set; }
        public int SalledeTheatreId { get; set; }
        public SalleDeTheatre? SalleDeTheatre { get; set; }

        //-----PIece
        public int PieceId { get; set; }
        public Piece? Piece { get; set; }
        //-----commande/reservation
        public List<Command>? Commands { get; set; }
    }
}
