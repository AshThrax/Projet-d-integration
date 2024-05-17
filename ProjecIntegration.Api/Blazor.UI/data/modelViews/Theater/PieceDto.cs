using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Blazor.UI.data.modelViews
{
    public class PieceDto : Baseview
    {

        public string Titre { get; set; } = string.Empty;
        public int Duree { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public List<RepresentationDto>? Representations { get; set; }
        public string? Image { get; set; }
        public int ThemeId { get; set; }
    }
    //ajoute une piece 
    public class AddPieceDto
    {
        public string Titre { get; set; } = string.Empty;
        public int Duree { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
        public int? ThemeId { get; set; }
    }
    //ajoute une piece 
    public class UpdatePieceDto: Baseview
    {
        public string Titre { get; set; } = string.Empty;
        public int Duree { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
        public string? Image { get; set; }
        public int? ThemeId { get; set; }
    }
}
