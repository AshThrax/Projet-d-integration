using ApplicationUser.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.Favorit
{
    public class AddFavoritDto : AddBaseDto
    {
        public int UserDetailId { get; set; }
        public List<int>? PieceFavorite { get; set; }
    }
}
