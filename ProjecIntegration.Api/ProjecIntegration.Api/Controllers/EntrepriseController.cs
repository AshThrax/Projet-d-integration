using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.entreprise;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepriseController : ControllerBase
    {
        private readonly IEntrepriseRepository _service;
        private readonly IMapper _mapper;
        public EntrepriseController(IEntrepriseRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EntrepriseDto>> GetById([FromBody] int id)
        {
            try
            {

                return Ok(_mapper.Map<Entreprise,EntrepriseDto>(await _service.GetById(id)));

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrepriseDto>>> GetAll()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Entreprise>, IEnumerable<EntrepriseDto>>(await _service.GetAll()));

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EntrepriseDto Entity)
        {
            try
            {

                if (Entity == null) { return BadRequest(); }
                var conversioon = _mapper.Map<EntrepriseDto, Entreprise>(Entity);
                _service.Insert(conversioon);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(int updtId,[FromBody] EntrepriseDto Entity)
        {
            try
            {
                if (Entity == null) { return BadRequest(); }
                var conversion = _mapper.Map<EntrepriseDto, Entreprise>(Entity);
                _service.Update(updtId,conversion);
                var ent = _mapper.Map<Entreprise, EntrepriseDto>(await _service.GetById(updtId));
                return Ok(ent);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Delete([FromBody] EntrepriseDto Entity)
        {
            try
            {
                if (Entity == null) {  throw new ArgumentNullException(nameof(Entity)); }
                var conversion = _mapper.Map<EntrepriseDto, Entreprise>(Entity);
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
