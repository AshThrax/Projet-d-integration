using Domain.Entity.PublicationEntity.Modération;
using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.UserEntity.UserDetails
{
    public class UserDetails : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public int ImageId { get; set; }
        public Image? Banner { get; set; }
        public List<Signalement>? HasSignalements { get; set; }
        public int FavorisId { get; set; }
        public Favorit? Favoris { get; set; }
    }
}
