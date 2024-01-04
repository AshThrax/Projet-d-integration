using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.Infrastructure.Service;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SallesDeThéatreController : ControllerBase
    {
        private readonly SalleDeTheatreService _service;

        public SallesDeThéatreController(SalleDeTheatreService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SalleDeTheatreDto>> GetById([FromBody] int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalleDeTheatreDto>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SalleDeTheatreDto Entity)
        {
           if(Entity == null) { return BadRequest(); }
            _service.Add(Entity);
           return Ok(Entity);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] SalleDeTheatreDto Entity)
        {
            if (Entity == null) { return BadRequest(); }
            var entity = await _service.Update(Entity);
            return Ok(entity);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Delete([FromBody] SalleDeTheatreDto Entity
        {
            _service.Delete(Entity);
            return NoContent();
        }
    }
}
