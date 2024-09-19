using ApplicationUser.Dto.Base;
using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.Favorit
{
    public class FavoritDto : BasicDto
    {

        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserDetailId { get; set; }
        public List<int>? PieceFavorite { get; set; }
    }
}
