using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.ticket;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _service;
        private readonly IMapper _mapper;
        public TicketController(ITicketRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketsDto>> GetById([FromBody] int id)
        {
            try
            {
                return Ok(_mapper.Map<Ticket, TicketsDto>(await _service.GetById(id)));

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketsDto>>> GetAll()
        {
            try
            {
                var Entity= await _service.GetAll();
                var conversion = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketsDto>>(Entity);
                return Ok(conversion);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TicketsDto Entity)
        {
            try
            {
                
                if (Entity == null) { return BadRequest(); }
                
                var conversion= _mapper.Map<TicketsDto,Ticket>(Entity);
                _service.Insert(conversion);
       
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(int updtId,[FromBody] TicketsDto Entity)
        {
            try
            {
                if (Entity == null) { return BadRequest(); }

                var conversion = _mapper.Map<TicketsDto, Ticket>(Entity);
                 _service.Update(updtId,conversion);

                return Ok(_mapper.Map<Ticket ,TicketsDto>(await _service.GetById(updtId)));

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Delete([FromBody] TicketsDto Entity)
        {
            try
            {
                var conversion = _mapper.Map<TicketsDto, Ticket>(Entity);
                _service.Delete(conversion);
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
    }
}
