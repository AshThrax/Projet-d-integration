using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;

namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RepresentationController : ControllerBase
    {
       
        private readonly IBusinessRepresentation _representationService;
        private readonly IBusinessCommandService _commandService;
        private readonly IMapper _mapper;
        private readonly ICustomGetToken gtk;

        public RepresentationController(IBusinessRepresentation representationService, IMapper mapper,IBusinessCommandService comandService, ICustomGetToken gtk)
        {
            _commandService = comandService;
            _representationService = representationService;
            _mapper = mapper;
            this.gtk = gtk;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAll()
        {
            try
            {
                var entities = await _representationService.GetAll();
                return Ok(_mapper.Map<IEnumerable<RepresentationDto>>(entities));

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
        [HttpGet("{id}")]
     
        public async Task<ActionResult<RepresentationDto>> GetById(int id)
        {
            try
            {
                var entities = await _representationService.GetById(id);
                var conversion = _mapper.Map<RepresentationDto>(entities);
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
      
        [HttpGet("get-piece/{idpiece}")]
     
        public async Task<ActionResult<RepresentationDto>> GetAllpieceById(int idpiece)
        {
            try
            {
                var entities = await _representationService.GetAllFromPiece(idpiece);
                return Ok(_mapper.Map<IEnumerable<RepresentationDto>>(entities));
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
        [HttpPost]
    
        public async Task<ActionResult> Create([FromBody] AddRepresentationDto entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest();
                }
                
                await _representationService.Create(entity);
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
     
        public async Task<ActionResult> Update(int updtId, [FromBody] UpdateRepresentationDto entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest();
                }
                
                await _representationService.Update(updtId,entity);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                await _representationService.Delete(id);
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
}
