namespace BlazorApp.data.modelViews
{
    public class CommandDto : Baseview
    {
        public string AuthId { get; set; }
        public int NombreDePlace { get; set; }
        public int IdRepresentation { get; set; }
    }
    public class AddCommandDto
    {
        public string AuthId { get; set; }
        public int NombreDePlace { get; set; }
        public int IdRepresentation { get; set; }
    }
    public class UpdateCommandDto : Baseview
    {
        public string AuthId { get; set; }
        public int NombreDePlace { get; set; }
        public int IdRepresentation { get; set; }
    }
}
