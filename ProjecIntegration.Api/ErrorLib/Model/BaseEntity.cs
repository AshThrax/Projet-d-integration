using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime Modified { get; set; }

        public string IPAddress { get; set; }

    }
}
