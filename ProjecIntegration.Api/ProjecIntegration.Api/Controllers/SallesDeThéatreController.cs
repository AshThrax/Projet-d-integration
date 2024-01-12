using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.salle;
using ProjecIntegration.Api.Infrastructure.Service;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SallesDeThéatreController : ControllerBase
    {
        private readonly ISalleDeTheatreRepository _service;
        private readonly IMapper _mapper;
        public SallesDeThéatreController(ISalleDeTheatreRepository service, IMapper mapper)
        {
            _service = service;$
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SalleDeTheatreDto>> GetById([FromBody] int id)
        {
            try
            {
                var conversion = _mapper.Map<SalleDeTheatre, SalleDeTheatreDto>(await _service.GetById(id));
                return Ok(conversion);
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
           
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalleDeTheatreDto>>> GetAll()
        {
            try
            {
                var conversion = _mapper.Map< IEnumerable<SalleDeTheatre>, IEnumerable<SalleDeTheatreDto>>(await _service.GetAll());
                return Ok(await _service.GetAll());

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SalleDeTheatreDto Entity)
        {
            try
            {
                var conversion = _mapper.Map<SalleDeTheatreDto, SalleDeTheatre>(Entity);
               _service.Insert(conversion);
               return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
            if (Entity == null) { return BadRequest(); }
        }
        [HttpPut]
        public async Task<ActionResult> Update(int updtId, [FromBody] SalleDeTheatreDto Entity)
        {
            try
            {
                if (Entity == null) { return BadRequest(); }
                var conversion = _mapper.Map<SalleDeTheatreDto, SalleDeTheatre>(Entity);
                _service.Update(updtId,conversion);
                return Ok(_mapper.Map<SalleDeTheatre, SalleDeTheatreDto>(await _service.GetById(updtId)));

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Delete([FromBody] SalleDeTheatreDto Entity)
        {
            try
            {
                var conversion = _mapper.Map<SalleDeTheatreDto, SalleDeTheatre>(Entity);
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
