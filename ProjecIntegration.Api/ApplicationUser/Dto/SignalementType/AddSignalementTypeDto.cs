using ApplicationUser.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.SignalementType
{
    public class AddSignalementTypeDto :AddBaseDto
    {
        public string Titre { get; set; } = string.Empty;
        public string Motif { get; set; } = string.Empty;
        public bool IsPertinent { get; set; }
    }
}
