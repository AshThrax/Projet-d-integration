using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.DTO
{
    public class SiegeDto: BaseDto
    {
        public string Name { get; set; }=string.Empty;  
        public int SalleId { get; set; }
    }
    public class AddSiegeDto 
    {
        public string Name { get; set; } = string.Empty;
        public int SalleId { get; set; }
    }
    public class UpdateSiegeDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public int SalleId { get; set; }
    }
}
