using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.UserEntity.FeedBack
{
    public class Feedback : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public int Evalutation { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
