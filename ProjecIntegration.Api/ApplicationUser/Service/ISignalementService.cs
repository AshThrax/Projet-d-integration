using ApplicationUser.Dto.Signalement;
using Domain.Entity.PublicationEntity.Modération;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUser.Service
{
    public interface ISignalementService : IService<Signalement,GetSignalementDto,AddSignalement,UpdateSignalementDto>
    {
    }
}
