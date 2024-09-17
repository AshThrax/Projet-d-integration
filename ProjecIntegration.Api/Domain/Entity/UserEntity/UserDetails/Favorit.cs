using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.UserEntity.UserDetails
{
    public class Favorit : BaseEntity
    {
        public int UserDetailId { get; set; }
        public UserDetails? UserDetail { get; set; }
        public List<int>? PieceFavorite { get; set; }
    }
}
