using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
using WebApi.ApiService.FileService;
namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PieceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusinessPiece _pieceRepository;
        private readonly IFileService fileService;

        public PieceController(IMapper mapper, IBusinessPiece pieceRepository,IFileService fileService)
        {
            this.fileService = fileService;
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
       
        public async Task<ActionResult<PieceDto>> GetById(int id)
        {
            try
            {
                var entity = await _pieceRepository.Get(id);
                var Conversion = _mapper.Map<PieceDto>(entity);
                if (Conversion == null)
                {
                    BadRequest();
                }
                return Ok(Conversion);
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
     
        public async Task<ActionResult> Create([FromForm] AddPieceDto addpiece)
        {
            try
            {
                if (addpiece.ImageFile?.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await fileService.SaveFileAsync(addpiece.ImageFile, allowedFileExtentions);

                _pieceRepository.Create(addpiece, createdImageName);
                      
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
      
        public async Task<ActionResult> Put(int updtId,[FromForm]UpdatePieceDto updatepiece)
        {

            try
            {
                 
                if (updatepiece.ImageFile != null)
                {
                    if (updatepiece.ImageFile?.Length > 1 * 1024 * 1024)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                    }
                    string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                    string createdImageName = await fileService.SaveFileAsync(updatepiece.ImageFile, allowedFileExtentions);
                    updatepiece.Image = createdImageName;
                }

                await _pieceRepository.Update(updtId, updatepiece);
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

        [HttpDelete("{id}")]
      
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                PieceDto piece = await  _pieceRepository.Get(id);
                if(piece !=null)
                {
                  
                   await _pieceRepository.Delete(id);

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
