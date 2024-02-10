namespace ProjecIntegration.Api.Application.DTO
{
    public class ComplexeDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public List<SalleDeTheatreDto> SalleDeTheatres { get; set; }
    }
    //ajoute un complexe a la base de donnée
    public class AddComplexeDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        
    }
    public class UpdateComplexeDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        
    }
}
