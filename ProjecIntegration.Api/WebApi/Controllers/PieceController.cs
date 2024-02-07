using data.Interfaces.IRepository;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPieceRepository _pieceRepository;

        public PieceController(IMapper mapper, IPieceRepository pieceRepository)
        {
            _mapper = mapper;
            _pieceRepository = pieceRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceDto>>> Get()
        {
            try
            {
                var entity = await _pieceRepository.GetAll();
                IEnumerable<PieceDto> Conversion = _mapper.Map<IEnumerable<PieceDto>>(entity);
                if (Conversion == null)
                {
                    BadRequest();
                }
                return Ok(Conversion);
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
        [HttpGet("get-complexe/{idComplexe}")]
        public async Task<ActionResult<IEnumerable<PieceDto>>> GetbyComplexe(int idComplexe)
        {
            try
            {
                var entity = await _pieceRepository.GetPieceByComplexe(idComplexe);
                var Conversion = _mapper.Map<IEnumerable<PieceDto>>(entity);
                if (Conversion == null)
                {
                    BadRequest();
                }
                return Ok(Conversion);
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
        public async Task<ActionResult<PieceDto>> GetById(int id) 
        {
            try
            {
                var entity = await _pieceRepository.GetById(id);
                var Conversion = _mapper.Map<PieceDto>(entity);
                if (Conversion == null)
                {
                    BadRequest();
                }
                return Ok(Conversion);
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
        public async Task<ActionResult> Create([FromBody] AddPieceDto piece)
        {
            try 
            {
                var Conversion = _mapper.Map<AddPieceDto,Piece>(piece);
                if (Conversion == null)
                {
                    BadRequest();
                }
                _pieceRepository.Insert(Conversion);
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
        [HttpPost("add-representation/{idPIece}")]
        public async Task<ActionResult> AddRepresnetation(int idPIece,[FromBody] AddRepresentationDto addRepresentation)
        {
            try
            {
                var Conversion = _mapper.Map<AddRepresentationDto, Representation>(addRepresentation);
                if (Conversion == null)
                {
                    BadRequest();
                }
                _pieceRepository.AddRepresentation(idPIece,Conversion);
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
        public async Task<ActionResult> Put(int updtId,UpdatePieceDto piece) 
        {

            try
            {

                var Conversion = _mapper.Map< UpdatePieceDto,Piece>(piece);

                if (Conversion == null)
                {
                    BadRequest();
                }
                _pieceRepository.Insert(Conversion);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {

            try
            {
                _pieceRepository.Delete(id);
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

        [HttpDelete("delete-representation/{id}/{idrepresentaion}")]
        public async Task<ActionResult> DeleteRepresentation(int id,int idrepresentaion)
        {

            try
            {
                _pieceRepository.DeleteRepresnetation(id,idrepresentaion);
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
