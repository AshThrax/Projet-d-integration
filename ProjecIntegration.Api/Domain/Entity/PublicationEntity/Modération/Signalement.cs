using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.PublicationEntity.Modération
{
    public  class Signalement :BaseEntity
    {
        public string UserSignaled { get; set; } =string.Empty;
        public string UserSignaling { get; set;  }= string.Empty;  
        public string Message { get; set; }= string.Empty;
        public bool IsReviewedByAdmin { get; set; }
        public bool IsPertinent { get; set; }
        public int SignalementTypeId { get; set; }
        public int UserDetailsId { get; set; }
        //clé Etrangére
        public SignalementType? SignalementType { get; set; }
        public UserDetails? UserDetails { get; set; }    

    }
}
