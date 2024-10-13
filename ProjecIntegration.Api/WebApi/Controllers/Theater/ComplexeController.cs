using ApplicationTheather.BusinessService.Complexe;
using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.Common.IRepository;
using Azure;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;
using Microsoft.AspNet.SignalR.Hosting;
using Stripe;
using WebApi.Validator.Theather;
namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ComplexeController : ControllerBase
    {
        private readonly IBusinessComplexe _complexeService;
        private readonly IMapper _mapper;
        public ComplexeController(
            IBusinessComplexe complexeService,
            IMapper mapper)
        {
            _mapper = mapper;
            _complexeService = complexeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComplexeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {

                ServiceResponse<ComplexeDto> response = await _complexeService.GetComplexe(id);
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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ComplexeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ComplexeDto>>> GetAll()
        {

            try
            {
                ServiceResponse<IEnumerable<ComplexeDto>> response = await _complexeService.GetAllComplexe();
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddComplexeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> Create([FromBody] AddComplexeDto complexe)
        {
            Console.WriteLine("entering api ");
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                var Validator = new AddComplexeValidator();
                var result = Validator.Validate(complexe);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }
                ServiceResponse<ComplexeDto> response= await _complexeService.CreateAsync(complexe);
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
        
        [HttpPut("{updtId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> Update(int updtId, [FromBody] UpdateComplexeDto complexe)
        {
            try
            {
                var Validator = new UpdtComplexeValidator();
                var result = Validator.Validate(complexe);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }

                ServiceResponse<ComplexeDto> response= await _complexeService.UpdateAsync(updtId, complexe);
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
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                ServiceResponse<ComplexeDto> response = await _complexeService.Delete(id);
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
    
    }
}
