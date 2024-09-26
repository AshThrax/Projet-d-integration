using ApplicationUser.Dto.SignalementType;
using Domain.Entity.PublicationEntity.Modération;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalementTypeController : GeneriqueController<SignalementType, GetSignalementTypeDto, AddSignalementTypeDto, UpdateSignalementTypeDto>
    {
        private readonly ISignalementTypeService _service;
        public SignalementTypeController(ISignalementTypeService service) : base(service)
        {
            _service=service;
        }
    }
}
