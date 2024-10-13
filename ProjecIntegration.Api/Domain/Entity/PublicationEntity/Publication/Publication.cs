using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Publication: BaseEntity
    { 
   
        public string Title { get; set; }=string.Empty;
   
        public string Review { get; set; }= string.Empty;
   
        public string  UserId { get; set; } =string.Empty;
    
        public int PieceId { get; set; }
     
        public int LikeNumber { get; set; }
      
        public ICollection<Post> Post { get; set; } = new List<Post>();
    
        public User? User { get; set; }
    }
}
