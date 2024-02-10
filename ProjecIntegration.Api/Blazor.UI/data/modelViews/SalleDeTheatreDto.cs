namespace Blazor.UI.modelViews
{
    public class SalleDeTheatreDto : Baseview
    {
        public string Name { get; set; }
        public int PlaceMax { get; set; }
        public int PlaceCurrent { get; set; }
        public int ComplexeId { get; set; }
        public List<RepresentationDto> Representations { get; set; }
    }
    public class AddSalleDeTheatreDto
    {
        public string Name { get; set; }
        public int PlaceMax { get; set; }
        public int PlaceCurrent { get; set; }
        public int ComplexeId { get; set; }

    }
    public class UpdateSalleDeTheatreDto : Baseview
    {
        public string Name { get; set; }
        public int PlaceMax { get; set; }
        public int PlaceCurrent { get; set; }
        public int ComplexeId { get; set; }

    }
}
