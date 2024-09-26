using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.UserEntity
{
    public class UserInterest : BaseEntity
    {
        public string UserId { get; set; } =string.Empty;
        public int ThemeId { get; set; }
        public decimal Score { get; set; }

     }
}
