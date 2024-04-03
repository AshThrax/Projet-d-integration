using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.notificationEntity
{
    public class Annonce
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EPrioirity Priority { get; set; }
        public DateTime Createtime { get; set; }
    }
}
