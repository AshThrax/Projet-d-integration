namespace BlazorApp.data.modelViews
{
    public class RepresentationDto : Baseview
    {
        public decimal Prix { get; set; }
        public DateTime Seance { get; set; }
        public int IdSalleDeTheatre { get; set; }
        public int IdPiece { get; set; }
        public List<CommandDto> Commands { get; set; }
    }
    //ajoute une representation a la database
    public class AddRepresentationDto
    {
        public decimal Prix { get; set; }
        public DateTime Seance { get; set; }
        public int IdSalleDeTheatre { get; set; }
        public int IdPiece { get; set; }

    }
    //mets a jout une representation dans la database
    public class UpdateRepresentationDto : Baseview
    {
        public decimal Prix { get; set; }
        public DateTime Seance { get; set; }
        public int IdSalleDeTheatre { get; set; }
        public int IdPiece { get; set; }

    }
}
