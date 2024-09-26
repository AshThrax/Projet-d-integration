namespace ApplicationTheather.DTO
{
    public class RepresentationDto : BaseDto
    {
        public int Prix { get; set; }
        public DateTime Seance { get; set; }
        public int PlaceMaximum { get; set; }
        public int PlaceCurrent { get; set; }
        //------salle de theatre
        public int SalledeTheatreId { get; set; }
        //-----PIece
        public int PieceId { get; set; }

        //-----commande/reservation
        public List<CommandDto>? Commands { get; set; }
    }
    //ajoute une representation a la database
    public class AddRepresentationDto
    {
        public int Prix { get; set; }
        public DateTime Seance { get; set; }
        public int PlaceMaximum { get; set; }
        public int PlaceCurrent { get; set; }
        //------salle de theatre
        public int SalledeTheatreId { get; set; }
        //-----PIece
        public int PieceId { get; set; }

        //-----commande/reservation

    }
    //mets a jout une representation dans la database
    public class UpdateRepresentationDto : BaseDto
    {
        public int Prix { get; set; }
        public DateTime Seance { get; set; }
        public int PlaceMaximum { get; set; }
        public int PlaceCurrent { get; set; }
        //------salle de theatre
        public int SalledeTheatreId { get; set; }
        //-----PIece
        public int PieceId { get; set; }

    }
}
