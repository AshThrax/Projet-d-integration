using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.UserEntity
{
    public class Follow : BaseEntity
    {
        public string FollowerId { get; set; }=string.Empty;
        public string FollowId { get; set; } =string.Empty;
    }
}
