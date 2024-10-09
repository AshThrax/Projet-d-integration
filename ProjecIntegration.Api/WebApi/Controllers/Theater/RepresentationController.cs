using ApplicationTheather.Common.Exceptions;
using Azure;
using Domain.DataType;
using Domain.ServiceResponse;
using Microsoft.AspNet.SignalR.Hosting;

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
        [HttpGet("bypage/{page}")]
        
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAll(int page )
        {
            try
            {
                ServiceResponse<IEnumerable<RepresentationDto>> entities = await _businessRepService.GetAll();
                Pagination<RepresentationDto> pageEntities= Pagination<RepresentationDto>.ToPagedList(entities.Data.ToList(),page,10);
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
                ServiceResponse<RepresentationDto> response = await _businessRepService.GetById(id);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
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
      
        [HttpGet("from-piece/{pieceId}/{page}")]
     
        public async Task<ActionResult<Pagination<RepresentationDto>>> GetAllpieceById(int pieceId,int page)
        {
            try
            {
                ServiceResponse<IEnumerable<RepresentationDto>> response = await _businessRepService.GetAllFromPiece(pieceId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<RepresentationDto> pageEntities = Pagination<RepresentationDto>.ToPagedList(response.Data.ToList(), page, 10);
                return Ok(pageEntities);
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
        [HttpGet("from-salle/{salleId}/{page}")]

        public async Task<ActionResult<Pagination<RepresentationDto>>> GetAllSalleById(int salleId, int page)
        {
            try
            {
                ServiceResponse<IEnumerable<RepresentationDto>> response=  await _businessRepService.GetAllFromSalle(salleId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<RepresentationDto> pageEntities = Pagination<RepresentationDto>.ToPagedList(response.Data.ToList(), page, 10);
                return Ok(pageEntities);
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
                
                ServiceResponse<RepresentationDto> response= await _businessRepService.Create(entity);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
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
                
                ServiceResponse<RepresentationDto> response = await _businessRepService.Update(updtId, entity);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
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

                ServiceResponse<RepresentationDto> response = await _businessRepService.Delete(id);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
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
