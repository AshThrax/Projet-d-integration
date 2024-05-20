using Blazor.UI.data.modelViews;

namespace Blazor.UI.Data.modelViews.Theater;

public class ComplexeDto : Baseview
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Adress { get; set; } = string.Empty;
    public List<SalleDeTheatreDto>? SalleDeTheatres { get; set; }
    public List<CatalogueDto>? Catalogue { get; set; }
    //public Entreprise Entreprise { get; set; }
    //public int EntrepriseID { get; set; }
}
//ajoute un complexe a la base de donnée
public class AddComplexeDto
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Adress { get; set; } = string.Empty;

    //public Entreprise Entreprise { get; set; }
    //public int EntrepriseID { get; set; }
}
public class UpdateComplexeDto : Baseview
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Adress { get; set; } = string.Empty;

    //public Entreprise Entreprise { get; set; }
    //public int EntrepriseID { get; set; }
}
