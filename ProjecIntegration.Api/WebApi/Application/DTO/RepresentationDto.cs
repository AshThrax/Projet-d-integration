namespace WebApi.Application.DTO
{
    public class RepresentationDto : BaseDto
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
    public class UpdateRepresentationDto : BaseDto
    {
        public decimal Prix { get; set; }
        public DateTime Seance { get; set; }
        public int IdSalleDeTheatre { get; set; }
        public int IdPiece { get; set; }

    }
}
