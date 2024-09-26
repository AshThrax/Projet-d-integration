using ApplicationTheather.Common.Exceptions;
using Domain.DataType;
using Domain.ServiceResponse;
using WebApi.ApiService.FileService;
namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class PieceController : ControllerBase
    {
        
        private readonly IBusinessPiece _pieceRepository;
        private readonly IBusinessCatalogue _businessCatalogue;
        private readonly IFileService fileService;

        public PieceController( IBusinessPiece pieceRepository,IBusinessCatalogue businessCatalogue,IFileService fileService)
        {
            this.fileService = fileService;
            _pieceRepository = pieceRepository;
            _businessCatalogue = businessCatalogue;
        }
        [HttpGet("{page}")]
        public async Task<ActionResult<Pagination<PieceDto>>> GetAllPiece(int page)
        {
            try
            { 
                ServiceResponse<IEnumerable<PieceDto>> response = await _pieceRepository.GetAll();
                Pagination<PieceDto> pagePiece = Pagination<PieceDto>.ToPagedList(response.Data.ToList(), page, 5);
                return Ok(pagePiece);
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
        [HttpGet("list")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<PieceDto>>>> GetAllPieceList()
        {
            try
            {
                ServiceResponse<IEnumerable<PieceDto>> response = await _pieceRepository.GetAll();
               
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
        [HttpGet("single/{id}")]
        public async Task<ActionResult<PieceDto>> GetById(int id)
        {
            try
            {
                ServiceResponse<PieceDto> response = await _pieceRepository.Get(id);
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
        [HttpGet("theme/{themeId}/{page}")]
        public async Task<ActionResult<PieceDto>> GetByThemeId(int themeId,int page)
        {
            try
            {
                ServiceResponse<IEnumerable<PieceDto>> response = await _pieceRepository.GetPieceByTheme(themeId);
                Pagination<PieceDto> pagePiece = Pagination<PieceDto>.ToPagedList(response?.Data?.ToList(), page, 5);
                return Ok(pagePiece);
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
        [HttpGet("catalogue/{catalogueId}/{page}")]
        public async Task<ActionResult<PieceDto>> GetByCatalogueId(int catalogueId,int page)
        {
            try
            {
                ServiceResponse<IEnumerable<PieceDto>> response = await _pieceRepository.GetPiecefromCatalogue(catalogueId);
                Pagination<PieceDto> pagePiece = Pagination<PieceDto>.ToPagedList(response.Data.ToList(), page, 5);
                return Ok(pagePiece);
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
        public async Task<ActionResult> CreatePiece([FromBody]AddPieceDto addpiece)
        {
            try
            {       if(ModelState.IsValid)
                    {

                       ServiceResponse<PieceDto> response= await _pieceRepository.Create(addpiece);
                      
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpGet("add-catalogue/{catalogueId}/{pieceId}")]
        public async Task<ActionResult> AddPieceToCatalogue(int catalogueId,int pieceId)
        {
            try
            {
                if (catalogueId == 0 && pieceId == 0)
                {
                    return BadRequest();
                }

               ServiceResponse<CatalogueDto> response= await _businessCatalogue.AddPieceToCatalogue(catalogueId, pieceId);
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
        [HttpGet("remove-catalogue/{catalogueId}/{pieceId}")]
        public async Task<ActionResult> RemovePieceFromCatalogue(int catalogueId, int pieceId)
        {
            try
            {
                if (catalogueId == 0 && pieceId == 0)
                {
                    return BadRequest();
                }
                ServiceResponse<CatalogueDto> response= await _businessCatalogue.RemovePieceToCataogue(catalogueId, pieceId);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{updtId}")]
        public async Task<ActionResult> UpdatePiece(int updtId,[FromForm]UpdatePieceDto updatepiece)
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

                ServiceResponse<PieceDto> response= await _pieceRepository.Update(updtId, updatepiece);
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
        public async Task<ActionResult<ServiceResponse<PieceDto>>> Delete(int id)
        {

            try
            {
               
                  
                ServiceResponse<PieceDto> response= await _pieceRepository.Delete(id);

               
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
