using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.Infrastructure.Service;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixController : ControllerBase
    {
        private readonly PrixService _prixService;
        public PrixController(PrixService prixService) {
            _prixService = prixService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrixDto>> GetById([FromBody] int id)
        {
            var entities = await _prixService.GetById(id);
            return Ok(entities);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrixDto>>> GetAll()
        {
            var entities = await _prixService.GetAll();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PrixDto AddPrix)
        {
            if (AddPrix == null)
            {
                BadRequest();
            }
            _prixService.Add(AddPrix);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PrixDto updtPrix)
        {
            if (updtPrix == null)
            {
                BadRequest();
            }
            _prixService.Update(updtPrix);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrixDto>> Delete([FromBody] PrixDto dto)
        {
            await _prixService.Delete(dto);
            return NoContent();
        }
    }
}
