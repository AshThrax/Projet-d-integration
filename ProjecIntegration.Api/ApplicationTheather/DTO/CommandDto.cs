namespace ApplicationTheather.DTO
{
    public class CommandDto : BaseDto
    {
        public string AuthId { get; set; }
        public int NombreDePlace { get; set; }
        public int IdRepresentation { get; set; }


    }
    public class AddCommandDto
    {
        public string? AuthId { get; set; }
        public int NombreDePlace { get; set; }
        public int IdRepresentation { get; set; }
    }
    public class UpdateCommandDto : BaseDto
    {
        public string? AuthId { get; set; }
        public int NombreDePlace { get; set; }
        public int IdRepresentation { get; set; }
    }
}
