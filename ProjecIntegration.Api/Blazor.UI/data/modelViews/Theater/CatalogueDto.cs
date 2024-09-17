using Blazor.UI.Data.ModelViews;

namespace Blazor.UI.Data.ModelViews.Theater;

public class CatalogueDto : Baseview
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int ComplexeId { get; set; }
}
public class UpdateCatalogueDto : Baseview
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int ComplexeId { get; set; }
}
public class AddCatalogueDto 
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int ComplexeId { get; set; }
}
