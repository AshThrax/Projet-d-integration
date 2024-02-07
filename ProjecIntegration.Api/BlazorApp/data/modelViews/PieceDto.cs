namespace BlazorApp.data.modelViews
{
    public class PieceDto : Baseview
    {
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }
        public int idSalle { get; set; }
        public List<RepresentationDto> Representations { get; set; }
    }
    //ajoute une piece 
    public class AddPieceDto
    {
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }


    }
    //ajoute une piece 
    public class UpdatePieceDto : Baseview
    {
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }
        public int idSalle { get; set; }

    }
}
