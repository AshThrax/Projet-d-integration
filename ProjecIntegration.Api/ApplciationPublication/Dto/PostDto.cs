using Domain.Entity.publicationEntity;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Dto
{
    public class PostDto : BaseDto
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public ICollection<RePost> Repost { get; set; } = new List<RePost>();
    }
}
