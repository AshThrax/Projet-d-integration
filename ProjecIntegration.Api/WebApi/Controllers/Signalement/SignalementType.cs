using ApplicationUser.Dto.Signalement;
using ApplicationUser.Dto.SignalementType;
using ApplicationUser.Repository;
using ApplicationUser.Service;
using Auth0.ManagementApi.Models;
using Domain.Entity.PublicationEntity.Modération;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
