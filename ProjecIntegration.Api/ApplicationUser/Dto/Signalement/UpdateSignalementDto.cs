using ApplicationUser.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Dto.Signalement
{
    public class UpdateSignalementDto:UpdateUserDetailDto
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserSignaled { get; set; } = string.Empty;
        public string UserSignaling { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsReviewedByAdmin { get; set; }
        public bool IsPertinent { get; set; }
        public int SignalementTypeId { get; set; }
        public int UserDetailsId { get; set; }
    }
}
