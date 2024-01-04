using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.Infrastructure.Service;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentationController : ControllerBase
    {
        private readonly RepresentationService _representationService;

        public RepresentationController(RepresentationService representationService) 
        { 
            _representationService = representationService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAll() 
        {
            var entities = await _representationService.GetAll();
            return Ok(entities);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RepresentationDto>> GetById([FromBody] int id)
        {
            var entities = await _representationService.GetById(id);
            return Ok(entities);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RepresentationDto entity)
        {
            if(entity == null) 
            {
                BadRequest();
            }
            _representationService.Add(entity);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] RepresentationDto entity)
        {
            if (entity == null)
            {
                BadRequest();
            }
            _representationService.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] RepresentationDto entity)
        {
            _representationService.Delete(entity);
            return NoContent();
        }
    }
}
