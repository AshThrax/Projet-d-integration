using data.Interfaces.IRepository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentationController : ControllerBase
    {
        private readonly IRepresentationRepository _representationService;
        private readonly IMapper _mapper;
        private readonly ICustomGetToken gtk;

        public RepresentationController(IRepresentationRepository representationService, IMapper mapper,ICustomGetToken gtk) 
        { 
            _representationService = representationService;
            _mapper = mapper;
            this.gtk = gtk;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAll() 
        {
            try
            {
                var entities = await _representationService.GetAll(c => c.SalleDeTheatre);
                return Ok(_mapper.Map<IEnumerable<RepresentationDto>>(entities));

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
        [HttpGet("{id}")]
        public async Task<ActionResult<RepresentationDto>> GetById( int id)
        {
            try
            {
                var entities = await _representationService.GetById(id,c =>c.SalleDeTheatre);
                var conversion=_mapper.Map<RepresentationDto>(entities);
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
        [HttpGet("get-salle/{id}")]
        public async Task<ActionResult<RepresentationDto>> GetAllSalleById( int idSalle)
        {
            try
            {
                var entities = await _representationService.GetAllBySalleId(idSalle);
                return Ok(_mapper.Map<IEnumerable<RepresentationDto>>(entities));
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
        [HttpGet("get-piece/{idpiece}")]
        public async Task<ActionResult<RepresentationDto>> GetAllpieceById(int idpiece)
        {
            try
            {
                var entities = await _representationService.GetAllByPieceId(idpiece);
                return Ok(_mapper.Map<IEnumerable<RepresentationDto>>(entities));
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
        public async Task<ActionResult> Create([FromBody] AddRepresentationDto entity)
        {
            try
            {
                   if (entity == null)
                   { 
                        BadRequest();
                   }
                  
                    var conversion = _mapper.Map<AddRepresentationDto,Representation>(entity);
                   _representationService.Insert(conversion);
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
        [HttpPost("add-command/{id}")]
        public async Task<ActionResult> AddCommand(int id,[FromForm] AddCommandDto entity)
        {
            try
            {
                if (entity == null)
                {
                    BadRequest();
                }

                entity.AuthId = await gtk.GetSub();
                var conversion = _mapper.Map<AddCommandDto,Command>(entity);
                _representationService.AddCommandToRepresentation(id,conversion);
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
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{updtId}")]
        public async Task<ActionResult> Update(int updtId,[FromBody] UpdateRepresentationDto entity)
        {
            try
            {
                if (entity == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<UpdateRepresentationDto, Representation>(entity);
                _representationService.Update(updtId, conversion);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               
                _representationService.Delete( id);
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
        [HttpDelete("delete-command/{idrepre}/{commandid}")]
        public async Task<ActionResult> Delete(int idrepre,int commandid)
        {
            try
            {
                
                _representationService.DeleteCommandRepresnetation(idrepre, commandid);
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
