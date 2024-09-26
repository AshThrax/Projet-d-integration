using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
    public class Favoris : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public List<Piece>? PieceFavorite { get; set; }
    }
}
