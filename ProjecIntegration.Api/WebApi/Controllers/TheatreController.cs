 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreBusiness _theatreBusiness;
        private readonly ILogger<TheatreController> logger;

        public TheatreController(ITheatreBusiness theatreBusiness, ILogger<TheatreController> logger)
        {
            this._theatreBusiness = theatreBusiness;
            this.logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="SalleId"></param>
        /// <returns></returns>
        [HttpPut("{pieceId}/{SalleId}")]
        public async Task<ActionResult> SetPieceSalle(int pieceId,int SalleId) 
        {
            try
            {
                 await _theatreBusiness.SetPieceSalle(pieceId, SalleId);
                
                return Ok();

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
        /// <param name="SalleId"></param>
        /// <param name="represnetation"></param>
        /// <returns></returns>
        [HttpPost("{pieceId}/{SalleId}")]
        public async Task<ActionResult> CreateRepresentaion(int pieceId,int SalleId,AddRepresentationDto represnetation) 
        {
            try
            {
                await _theatreBusiness.CreateRepresentationForPiece(pieceId, SalleId, represnetation);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="repId"></param>
        /// <returns></returns>
        [HttpDelete("{pieceId}/{repId}")]
        public async Task<ActionResult> Deleterepresnetation(int pieceId,int repId) 
        {
            try
            {
                await _theatreBusiness.DeleteRepresentationForPiece(pieceId, repId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpGet("{IdPiece}")]
        public async Task<ActionResult> GetRepresnetationFromPiece(int IdPiece) 
        {
            try
            {
                var GetRepPiece= await _theatreBusiness.GetRepresentationFromPiece(IdPiece);
                return Ok(GetRepPiece);
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
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Complexe"></param>
        /// <returns></returns>
        [HttpGet("{IdComplexe}")]
        public async Task<ActionResult> GetAllPieceFromComplexe(int IdComplexe) 
        {
            try 
            { 
                var getComplexe= await _theatreBusiness.GetallPieceFromComplexe(IdComplexe);
                return Ok(getComplexe);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
