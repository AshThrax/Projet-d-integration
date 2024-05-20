using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
namespace WebApi.Controllers.Theater;

[Route("api/v1/[controller]")]
[ApiController]
public class SallesDeTheatreController : ControllerBase
{
    private readonly ISalleDeTheatreRepository _service;
    private readonly IMapper _mapper;
    public SallesDeTheatreController(ISalleDeTheatreRepository service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
        [HttpGet("{id}")]
  
        public async Task<ActionResult<SalleDeTheatreDto>> GetById(int id)
        {
            try
            {
                var conversion = _mapper.Map<SalleDeTheatreDto>(await _service.GetById(id));
                return Ok(conversion);
            }
          catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-complexe/{id}")]
        public async Task<ActionResult<SalleDeTheatreDto>> GetByComplexe(int id)
        {
            try
            {
                var entities = await _service.GetByIdComplexe(id);
                var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(entities);
                return Ok(conversion);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<SalleDeTheatreDto>>> GetAll()
        {
            try
            {
                var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(await _service.GetAll());
                return Ok(conversion);

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("")]
        public async Task<ActionResult> Create([FromBody] AddSalleDeTheatreDto Entity)
        {
            try
            {
                var conversion = _mapper.Map<SalleDeTheatre>(Entity);
                _service.Insert(conversion);
                return Ok();

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{updtId}")]
      
        public async Task<ActionResult<SalleDeTheatreDto>> Update(int updtId, [FromBody] UpdateSalleDeTheatreDto Entity)
        {
            try
            {
                if (Entity == null) { return BadRequest(); }
                var conversion = _mapper.Map<UpdateSalleDeTheatreDto, SalleDeTheatre>(Entity);
               _service.Update(updtId, conversion);
                return Ok(_mapper.Map<SalleDeTheatre, SalleDeTheatreDto>(await _service.GetById(updtId)));

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
       
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                await _service.Delete(id);
                return NoContent();

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-representation/{idSalle}/{idrepresentation}")]
        public async Task<ActionResult> DeleteRepresentation(int idSalle, int idrepresentation)
        {
            try
            {
                await _service.DeleteRepresentationToSalle(idSalle, idrepresentation);
                return NoContent();

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}


