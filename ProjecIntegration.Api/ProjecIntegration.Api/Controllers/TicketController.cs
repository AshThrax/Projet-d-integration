using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.Infrastructure.Service;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _service;

        public TicketController(TicketService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketsDto>> GetById([FromBody] int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketsDto>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TicketsDto Entity)
        {
            if (Entity == null) { return BadRequest(); }
            
            _service.Add(Entity);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TicketsDto Entity)
        {
            if (Entity == null) { return BadRequest(); }
            var entity = await _service.Update(Entity);
            return Ok(entity);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Delete([FromBody] TicketsDto Entity)
        {
            _service.Delete(Entity);
            return NoContent();
        }
    }
}
