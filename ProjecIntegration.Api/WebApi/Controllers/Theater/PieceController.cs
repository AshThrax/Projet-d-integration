using ApplicationTheather.Common.Exceptions;
using Domain.DataType;
using Domain.ServiceResponse;
using WebApi.ApiService.FileService;
using WebApi.Validator.Theather;
namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
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
                if (response.Success)
                {
                    return Ok(response);
                }
                else 
                {
                    return BadRequest(response);
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
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
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
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CreatePiece([FromBody]AddPieceDto addpiece)
        {
            try
            {       
                if(ModelState.IsValid)
                {
                    var Validator = new AddPieceValidator();
                    var result = Validator.Validate(addpiece);
                    if (!result.IsValid)
                    {
                        return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                    }
                    ServiceResponse<PieceDto> response= await _pieceRepository.Create(addpiece);
                    if (!response.Success)
                    {
                        return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                    }
                    return Ok(response);
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
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> AddPieceToCatalogue(int catalogueId,int pieceId)
        {
            try
            {
                if (catalogueId == 0 && pieceId == 0)
                {
                    return BadRequest();
                }

               ServiceResponse<CatalogueDto> response= await _businessCatalogue.AddPieceToCatalogue(catalogueId, pieceId);
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
        [HttpGet("remove-catalogue/{catalogueId}/{pieceId}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> RemovePieceFromCatalogue(int catalogueId, int pieceId)
        {
            try
            {
                if (catalogueId == 0 && pieceId == 0)
                {
                    return BadRequest();
                }
                ServiceResponse<CatalogueDto> response= await _businessCatalogue.RemovePieceToCataogue(catalogueId, pieceId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{updtId}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> UpdatePiece(int updtId,[FromBody]UpdatePieceDto updatepiece)
        {

            try
            {

                var Validator = new UpdtPieceValidator();
                var result = Validator.Validate(updatepiece);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }

                ServiceResponse<PieceDto> response= await _pieceRepository.Update(updtId, updatepiece);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<PieceDto>>> Delete(int id)
        {

            try
            {
               
                  
                ServiceResponse<PieceDto> response= await _pieceRepository.Delete(id);
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
