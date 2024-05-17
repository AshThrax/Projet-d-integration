using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
     public class Theme :BaseEntity
     {
       public ETheme? EThemePiece{ get; set; }=ETheme.Comedie;
     }
}
