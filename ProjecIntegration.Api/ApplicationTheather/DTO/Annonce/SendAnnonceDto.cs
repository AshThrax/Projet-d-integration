using ApplicationTheather.DTO;
using Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAnnonce.DTO
{
    public class AddAnnonceDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int PieceId { get; set; }
        public EPrioirity Priority { get; set; }

    }
    public class GetAnnonceDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int PieceId { get; set; }
        public EPrioirity Priority { get; set; }

    }
    public class UpdateAnnonceDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int PieceId { get; set; }
        public EPrioirity Priority { get; set; }
    }
}
