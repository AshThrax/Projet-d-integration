namespace Blazor.UI.modelViews
{
    public class ComplexeDto : Baseview
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
    public class UpdateComplexeDto : Baseview
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

    }
}
