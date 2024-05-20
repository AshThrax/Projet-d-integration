

namespace Blazor.UI.Data.modelViews.Theater;

public class RepresentationDto : Baseview
{
    public int Prix { get; set; }
    public DateTime Seance { get; set; }
    public int PlaceMaximum { get; set; }
    public int PlaceCurrent { get; set; }
    //------salle de theatre
    public int IdSalledeTheatre { get; set; }

    //-----PIece
    public int IdPiece { get; set; }

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
    public int IdSalledeTheatre { get; set; }
    //-----PIece
    public int IdPiece { get; set; }
}
//mets a jout une representation dans la database
public class UpdateRepresentationDto : Baseview
{
    public int Prix { get; set; }
    public DateTime Seance { get; set; }
    public int PlaceMaximum { get; set; }
    public int PlaceCurrent { get; set; }
    //------salle de theatre
    public int IdSalledeTheatre { get; set; }
    //-----PIece
    public int IdPiece { get; set; }
}
