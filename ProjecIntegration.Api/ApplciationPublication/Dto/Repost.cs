using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Dto
{
    public class RepostDto :BaseDto
    {
       
        public string Content { get; set; }
      
        public string UserId { get; set; }
    }
}
