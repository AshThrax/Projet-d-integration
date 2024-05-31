using Blazor.UI.data.modelViews;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Blazor.UI.Data.modelViews.Theater;

public class PieceDto : Baseview
{

    public string Titre { get; set; } = string.Empty;
    public int Duree { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public List<RepresentationDto>? Representations { get; set; }
    public int ImageId { get; set; }
    public ImageDto? Image { get; set; }
    public int ThemeId { get; set; }
}
//ajoute une piece 
public class AddPieceDto
{
    public string Titre { get; set; }
    public int Duree { get; set; }
    public string Description { get; set; }
    public string Auteur { get; set; }
    public IFormFile ImageFile { get; set; }
    public int? ThemeId { get; set; }
}
//ajoute une piece 
public class UpdatePieceDto : Baseview
{
    public string Titre { get; set; }
    public int Duree { get; set; }
    public string Description { get; set; }
    public string Auteur { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Image { get; set; }
    public int? ThemeId { get; set; }
}
