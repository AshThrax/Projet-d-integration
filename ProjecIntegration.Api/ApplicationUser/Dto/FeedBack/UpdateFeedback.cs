using ApplicationUser.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.FeedBack
{
    public class UpdateFeedbackDto : UpdateUserDetailDto
    {
        int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Evalutation { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
