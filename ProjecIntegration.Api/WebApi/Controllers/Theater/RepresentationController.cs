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
       
        private readonly IBusinessRepresentation _businessRepService;
        private readonly IBusinessCommandService _businessComService;
        private readonly IMapper _mapper;
        private readonly ICustomGetToken gtk;

        public RepresentationController(IBusinessRepresentation businessRepService, IMapper mapper,IBusinessCommandService businessComService, ICustomGetToken gtk)
        {
            _businessComService = businessComService;
            _businessRepService = businessRepService;
            _mapper = mapper;
            this.gtk = gtk;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAll()
        {
            try
            {
                IEnumerable<RepresentationDto> entities = await _businessRepService.GetAll();
                return Ok(entities);

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
                RepresentationDto entities = await _businessRepService.GetById(id);
             
                return Ok(entities);
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
      
        [HttpGet("from-piece/{idpiece}")]
     
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAllpieceById(int pieceId)
        {
            try
            {
                IEnumerable<RepresentationDto> entities = await _businessRepService.GetAllFromPiece(pieceId);
                return Ok(entities);
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
        [HttpGet("from-salle/{salleId}")]

        public async Task<ActionResult<RepresentationDto>> GetAllSalleById(int salleId)
        {
            try
            {
              IEnumerable<RepresentationDto> getfromsalle=  await _businessRepService.GetAllFromSalle(salleId);
                return Ok(getfromsalle);
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
    
        public async Task<ActionResult> Createrepresentation([FromBody] AddRepresentationDto entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest();
                }
                
                await _businessRepService.Create(entity);
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
     
        public async Task<ActionResult> UpdateRepresentation(int updtId, [FromBody] UpdateRepresentationDto entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest();
                }
                
                await _businessRepService.Update(updtId,entity);
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
        public async Task<ActionResult> DeleteRepresentation(int id)
        {
            try
            {

                await _businessRepService.Delete(id);
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
