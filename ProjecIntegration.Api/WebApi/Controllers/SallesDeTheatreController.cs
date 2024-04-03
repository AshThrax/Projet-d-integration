using dataInfraTheather.Models.Entity;
using dataInfraTheather.Repository.Interfaces.IRepository;
using WebApi.Application.Common.Exceptions;
using WebApi.Application.DTO;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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
                var conversion = _mapper.Map<SalleDeTheatreDto>(await _service.GetById(id,c=>c.Pieces));
                return Ok(conversion);
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("get-complexe/{id}")]
        public async Task<ActionResult<SalleDeTheatreDto>> GetByComplexe( int id)
        {
            try
            {
                var entities = await _service.GetByIdComplexe(id);
                var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(entities);
                return Ok(conversion);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch(NotFoundException ex) 
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message+"");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalleDeTheatreDto>>> GetAll()
        {
            try
            {
                var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(await _service.GetAll(c=>c.Pieces));
                return Ok(conversion);

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddSalleDeTheatreDto Entity)
        {
            try
            {
                var conversion = _mapper.Map<AddSalleDeTheatreDto, SalleDeTheatre>(Entity);
               _service.Insert(conversion);
               return Ok();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpPost("add-piece/{idSalle}")]
        public async Task<ActionResult> AddPiece(int idSalle,[FromBody] AddPieceDto Entity)
        {
            try
            {
                var conversion = _mapper.Map<Piece>(Entity);
                _service.AddPieceToSalle(idSalle,conversion);
                return Ok();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpPut("{updtId}")]
        public async Task<ActionResult> Update(int updtId, [FromBody] UpdateSalleDeTheatreDto Entity)
        {
            try
            {
                if (Entity == null) { return BadRequest(); }
                var conversion = _mapper.Map<UpdateSalleDeTheatreDto, SalleDeTheatre>(Entity);
                _service.Update(updtId,conversion);
                return Ok(_mapper.Map<SalleDeTheatre, SalleDeTheatreDto>(await _service.GetById(updtId)));

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               
                _service.Delete(id);
                return NoContent();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpDelete("delete-representation/{idSalle}/{idrepresentation}")]
        public async Task<ActionResult> DeleteRepresentation(int idSalle,int idrepresentation)
        {
            try
            {
                _service.DeleteRepresentationToSalle(idSalle, idrepresentation);
                return NoContent();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpDelete("delete-piece/{idSalle}/{IdPiece}")]
        public async Task<ActionResult> Delete(int idSalle,int IdPiece)
        {
            try
            {

                _service.DeletePieceToSalle(idSalle, IdPiece);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
    }
}
