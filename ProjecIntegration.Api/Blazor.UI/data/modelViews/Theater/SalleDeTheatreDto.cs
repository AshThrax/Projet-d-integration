using Blazor.UI.data.modelViews;

namespace Blazor.UI.Data.modelViews.Theater;

public class SalleDeTheatreDto : Baseview
{
    public string Name { get; set; } = string.Empty;

    public int PlaceMax { get; set; }

    public int ComplexeId { get; set; }

    public List<RepresentationDto>? Representations { get; set; }
}
public class AddSalleDeTheatreDto
{
    public string Name { get; set; } = string.Empty;

    public int PlaceMax { get; set; }

    public int ComplexeId { get; set; }

}
public class UpdateSalleDeTheatreDto : Baseview
{
    public string Name { get; set; } = string.Empty;

    public int PlaceMax { get; set; }

    public int ComplexeId { get; set; }

}
