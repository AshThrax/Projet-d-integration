using dataInfraTheather.Models.Entity;
using dataInfraTheather.Repository.Interfaces.IRepository;
using WebApi.Application.Common.Exceptions;
using WebApi.Application.DTO;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
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
            catch (ArgumentNullException ex)
            {
                return StatusCode(500, "pas d'argument");
            }
            catch (Exception e)
            {
                return StatusCode(500, "exception classique");
            }
        }
        [HttpPost("add-Salle/{idComplexe}")]
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
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {

                _complexeService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("delete-salle/{idComplexe}/{idSalle}")]
        public ActionResult Delete(int idComplexe, int idSalle)
        {
            try
            {
                _complexeService.DeletesalleDetheatre(idComplexe, idSalle);
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
