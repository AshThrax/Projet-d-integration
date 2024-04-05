using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Dto
{
    public class PublicationDto:BaseDto
    {
       
        public string Title { get; set; }
       
        public string Review { get; set; }
       
        public string UserId { get; set; }
        
        public int PieceId { get; set; }
        public ICollection<string> post { get; set; } = new List<string>();
    }
    public class AddPublicationDto
    {
        
        public string Title { get; set; }
        
        public string Review { get; set; }
       
        public string UserId { get; set; }

        public int PieceId { get; set; }
        public ICollection<string> post { get; set; } = new List<string>();
    }
    public class UpdatePublicationDto:BaseDto
    {
       
        public string Title { get; set; }
        
        public string Review { get; set; }

        public int PieceId { get; set; }
        public string UserId { get; set; }
      
        public ICollection<string> post { get; set; } = new List<string>();
    }
}
