using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
    public class CataloguePiece
    {
        [ForeignKey(nameof(Catalogue))]
        public int CatalogueId { get; set; }
        public Catalogue Catalogue { get; set; }
        [ForeignKey(nameof(Piece))]
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
    }
}
