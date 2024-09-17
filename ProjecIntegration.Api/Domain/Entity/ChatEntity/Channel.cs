using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.ChatEntity
{
    public class Channel: BaseMongoEntity
    {
        public List<ChatMessage> ChatMessages { get; set; }
        public string ChatUserId_1 { get; set; }=string.Empty;
        public string ChatUserId_2 { get; set; } = string.Empty;
    }
}
