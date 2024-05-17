using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.DTO;

namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreBusiness _theatreBusiness;
        private readonly ILogger<TheatreController> logger;

        public TheatreController(ITheatreBusiness theatreBusiness, ILogger<TheatreController> logger)
        {
            _theatreBusiness = theatreBusiness;
            this.logger = logger;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="SalleId"></param>
        /// <param name="represnetation"></param>
        /// <returns></returns>
        [HttpPost("{pieceId}/{SalleId}")]
        public async Task<ActionResult> CreateRepresentaion(int pieceId, int SalleId, AddRepresentationDto represnetation)
        {
            try
            {
                await _theatreBusiness.CreateRepresentationForPiece(pieceId, SalleId, represnetation);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="repId"></param>
        /// <returns></returns>
        [HttpDelete("{pieceId}/{repId}")]
        public async Task<ActionResult> Deleterepresnetation(int pieceId, int repId)
        {
            try
            {
                await _theatreBusiness.DeleteRepresentationForPiece(pieceId, repId);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpGet("{IdPiece}")]
        public async Task<ActionResult> GetRepresentationFromPiece(int IdPiece)
        {
            try
            {
                var GetRepPiece = await _theatreBusiness.GetRepresentationFromPiece(IdPiece);
                return Ok(GetRepPiece);
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
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpGet("{IdSalle}")]
        public async Task<ActionResult> GetRepresnetationFromSalle(int IdSalle)
        {
            try
            {
                var GetRep = await _theatreBusiness.GetRepresentationFromPiece(IdSalle);
                return Ok(GetRep);
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
