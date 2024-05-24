using Domain.Entity.TheatherEntity;
using Microsoft.AspNetCore.Http;

namespace ApplicationTheather.DTO
{
    public class PieceDto : BaseDto
    {

        public string Titre { get; set; } = string.Empty;
        public int Duree { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public List<RepresentationDto>? Representations { get; set; }
        public int ImageId { get; set; }
        public string ImageRessource { get; set; } =string .Empty;
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
    public class UpdatePieceDto : BaseDto
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
