namespace ProjecIntegration.Api.Application.DTO
{
    public class EntrepriseDto :BaseDto
    {
        public string Nom { get; set; }
        public string Adress { get; set; }
        public List<ComplexeDto> Complexes { get; set; }
    }
}
