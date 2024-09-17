using ApplicationUser.Dto.Signalement;
using ApplicationUser.Service;
using Auth0.ManagementApi.Models;
using Domain.Entity.PublicationEntity.Modération;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalementController : GeneriqueController<Signalement, GetSignalementDto, AddSignalement, UpdateSignalementDto>
    {
        public SignalementController(IService<Signalement, GetSignalementDto, AddSignalement, UpdateSignalementDto> service) : base(service)
        {
        }
    }
}
