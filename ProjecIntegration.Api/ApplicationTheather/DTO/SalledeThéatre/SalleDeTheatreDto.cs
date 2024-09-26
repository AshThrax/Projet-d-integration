namespace ApplicationTheather.DTO
{
    public class SalleDeTheatreDto : BaseDto
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
    public class UpdateSalleDeTheatreDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;

        public int PlaceMax { get; set; }

        public int ComplexeId { get; set; }

    }
}
