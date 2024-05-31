using AutoMapper;
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
        public string? Image { get; set; }
        public int ThemeId { get; set; }

        public  List<PieceDto> ConvertToDtos(List<Piece> piecesToConvert,IMapper map) 
        {
            List<PieceDto> getPieceDtoConverter = new List<PieceDto>();

            foreach (Piece item in piecesToConvert)
            {
                PieceDto piece = new PieceDto() 
                {
                    Auteur = item.Auteur,
                    Description = item.Description,
                    Duree = item.Duree,
                    AddedTime = item.CreatedDate,
                    Id = item.Id,
                    Representations =map.Map<List<RepresentationDto>>(item.Representations),
                    ImageId = item.ImageId,
                    Image = item.Image?.ImageRessource,
                    ThemeId = item.ThemeId,
                    Titre = item.Titre,
                };
                getPieceDtoConverter.Add(piece);
            }
            return getPieceDtoConverter;
        }
        public  List<PieceDto> ConvertToDtos(IEnumerable<Piece> piecesToConvert, IMapper map)
        {
            List<PieceDto> getPieceDtoConverter = new List<PieceDto>();

            foreach (Piece item in piecesToConvert)
            {
                PieceDto piece = new PieceDto()
                {
                    Auteur = item.Auteur,
                    Description = item.Description,
                    Duree = item.Duree,
                    AddedTime = item.CreatedDate,
                    Id = item.Id,
                    Representations = map.Map<List<RepresentationDto>>(item.Representations),
                    ImageId = item.ImageId,
                    Image = item.Image?.ImageRessource,
                    ThemeId = item.ThemeId,
                    Titre = item.Titre,
                };
                getPieceDtoConverter.Add(piece);
            }
            return getPieceDtoConverter;
        }
        public PieceDto ConvertToDtos(Piece piecesToConvert, IMapper map)
        {
                PieceDto piece = new PieceDto()
                {
                    Auteur = piecesToConvert.Auteur,
                    Description = piecesToConvert.Description,
                    Duree = piecesToConvert.Duree,
                    AddedTime = piecesToConvert.CreatedDate,
                    Id = piecesToConvert.Id,
                    Representations = map.Map<List<RepresentationDto>>(piecesToConvert.Representations),
                    ImageId = piecesToConvert.ImageId,
                    Image = piecesToConvert?.Image?.ImageRessource,
                    ThemeId = piecesToConvert.ThemeId,
                    Titre = piecesToConvert.Titre,
                };
            return piece;
        }
    }
    //ajoute une piece 
    public class AddPieceDto
    {
        public string Titre { get; set; } = string.Empty;
        public int Duree { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public int ImageId { get; set; }
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
