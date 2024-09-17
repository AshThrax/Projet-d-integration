using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.ChatEntity
{
    public class ChatMessage :BaseMongoEntity
    {
        public string Content { get; set; }=string.Empty;
        public string userId { get; set; } = string.Empty;
    }
}
