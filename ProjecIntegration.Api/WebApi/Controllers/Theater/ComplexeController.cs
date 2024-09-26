using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.Common.IRepository;
using Domain.Entity.TheatherEntity;
namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ComplexeController : ControllerBase
    {
        private readonly IComplexeRepository _complexeService;
        private readonly IMapper _mapper;
        public ComplexeController(
            IComplexeRepository complexeService,
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
                var entity = await _complexeService.GetById(id, c => c.SalleDeTheatres);
                var conversion = _mapper.Map<ComplexeDto>(entity);
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
                var entity = await _complexeService.GetAll(c => c.SalleDeTheatres);
                var conversion = _mapper.Map<IEnumerable<ComplexeDto>>(entity);
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddComplexeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create([FromBody] AddComplexeDto complexe)
        {
            Console.WriteLine("entering api ");
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<Complexe>(complexe);
                _complexeService.Insert(conversion);
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
        [HttpPost("add-Salle/{idComplexe}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddSalleDeTheatreDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddSalle(int idComplexe, [FromBody] AddSalleDeTheatreDto salle)
        {
            Console.WriteLine("entering api ");
            try
            {
                if (salle == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<SalleDeTheatre>(salle);
                _complexeService.AddSalledeTheatre(idComplexe, conversion);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Update(int updtId, [FromBody] UpdateComplexeDto complexe)
        {
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<Complexe>(complexe);
                _complexeService.Update(updtId, conversion);
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
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {

                _complexeService.Delete(id);
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
        [HttpDelete("delete-salle/{idComplexe}/{idSalle}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int idComplexe, int idSalle)
        {
            try
            {
                _complexeService.DeletesalleDetheatre(idComplexe, idSalle);
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
