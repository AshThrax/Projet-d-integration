using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Dto
{
    public class BannerDto
    {
        public int Id { get; set; } 
        public string UserId { get; set; }=string.Empty;
        public string ImageRessource { get; set; } = string.Empty;
    }
}
