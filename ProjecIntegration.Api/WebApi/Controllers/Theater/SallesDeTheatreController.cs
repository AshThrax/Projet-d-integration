using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
namespace WebApi.Controllers.Theater;

[Route("api/v1/[controller]")]
[ApiController]
public class SallesDeTheatreController : ControllerBase
{
        private readonly IBusinessSalle _bussinessServices;
      
        private readonly IMapper _mapper;
        public SallesDeTheatreController(IBusinessSalle bussinessServices, IMapper mapper)
        {
            _bussinessServices= bussinessServices;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
  
        public async Task<ActionResult<SalleDeTheatreDto>> GetSalleById(int id)
        {
            try
            {
                SalleDeTheatreDto getSalle= await _bussinessServices.GetSalle(id);

                return Ok(getSalle);
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
        public async Task<ActionResult<SalleDeTheatreDto>> GetSalleByComplexe(int id)
        {
            try
            {
                IEnumerable<SalleDeTheatreDto> getSalles= await _bussinessServices.GetFromComplexe(id);
                return Ok(getSalles);
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

        public async Task<ActionResult<IEnumerable<SalleDeTheatreDto>>> GetAllSalle()
        {
            try
            {
                IEnumerable<SalleDeTheatreDto> getSalles = await _bussinessServices.GetAllSalle();
                return Ok(getSalles);

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
        public async Task<ActionResult> CreateSalle([FromBody] AddSalleDeTheatreDto Entity)
        {
            try
            {
                 await _bussinessServices.CreateSalle(Entity.ComplexeId,Entity);
                return Ok(Entity);
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
            if (updtId <= 0)
            {
                return BadRequest(updtId);
            }
            try
            {
                if (Entity == null) { return BadRequest(); }
               
                await _bussinessServices.Updatesalle(updtId,Entity);

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
       
        public async Task<ActionResult> DeleteSalle(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            try
            {
                await _bussinessServices.DeleteSalle(id);
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


