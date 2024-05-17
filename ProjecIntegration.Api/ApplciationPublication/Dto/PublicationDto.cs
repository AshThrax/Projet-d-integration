using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Dto
{
    public class PublicationDto : BaseDto
    {

        public string Title { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public int PieceId { get; set; }
        public ICollection<string> post { get; set; } = new List<string>();
    }
    public class AddPublicationDto
    {

        public string Title { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public int PieceId { get; set; }
        public ICollection<string> post { get; set; } = new List<string>();
    }
    public class UpdatePublicationDto : BaseDto
    {

        public string Title { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public int PieceId { get; set; }
        public string UserId { get; set; } = string.Empty;

        public ICollection<string> post { get; set; } = new List<string>();
    }
}
