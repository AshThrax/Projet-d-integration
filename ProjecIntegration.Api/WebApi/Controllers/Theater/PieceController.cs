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
        
        private readonly IBusinessPiece _pieceRepository;
        private readonly IBusinessCatalogue _businessCatalogue;
        private readonly IFileService fileService;

        public PieceController( IBusinessPiece pieceRepository,IBusinessCatalogue businessCatalogue,IFileService fileService)
        {
            this.fileService = fileService;
            _pieceRepository = pieceRepository;
            _businessCatalogue = businessCatalogue;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceDto>>> GetAllPiece()
        {
            try
            { 
              
                return Ok(await _pieceRepository.GetAll());
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
                return Ok(entity);
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
        [HttpGet("theme/{themeId}")]
        public async Task<ActionResult<PieceDto>> GetByThemeId(int themeId)
        {
            try
            {
                var entity = await _pieceRepository.GetPieceByTheme(themeId);
              
                return Ok(entity);
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
        [HttpGet("catalogue/{catalogueId}")]
        public async Task<ActionResult<PieceDto>> GetByCatalogueId(int catalogueId)
        {
            try
            {
                return Ok(await _pieceRepository.GetPiecefromCatalogue(catalogueId));
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
        public async Task<ActionResult> CreatePiece(AddPieceDto addpiece)
        {
            try
            {       if(ModelState.IsValid)
                    {

                        if (addpiece.ImageFile?.Length > 1 * 1024 * 1024)
                        {
                            return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                        }
                        string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                        string createdImageName = await fileService.SaveFileAsync(addpiece.ImageFile, allowedFileExtentions);

                        Image CreateImg=new Image();
                        CreateImg.ImageRessource = createdImageName;
                        
                        _pieceRepository.Create(addpiece, CreateImg);
                      
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

                await _businessCatalogue.AddPieceToCatalogue(catalogueId, pieceId);
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
                await _businessCatalogue.RemovePieceToCataogue(catalogueId, pieceId);
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

                await _pieceRepository.Update(updtId, updatepiece);
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
