﻿using Domain.Entity.publicationEntity;
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
        public string Content { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ICollection<RepostDto> Repost { get; set; } = new List<RepostDto>();
    }
}
