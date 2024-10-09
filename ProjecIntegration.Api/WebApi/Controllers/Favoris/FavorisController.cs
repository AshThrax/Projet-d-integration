using Domain.DataType;
using Domain.ServiceResponse;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FavorisController : ControllerBase
    {
        private readonly IBusinessFavoris _businessFavoris;
        private readonly ICustomGetToken _customCetToken;
        public FavorisController(IBusinessFavoris businessFavoris, ICustomGetToken customCetToken)
        {
            _businessFavoris = businessFavoris;
            _customCetToken = customCetToken;
        }
        /// <summary>
        /// add a piece to favorite
        /// </summary>
        /// <param name="favorisId"></param>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpPost("addfavoris/{pieceId}")]
        public async Task<ActionResult<ServiceResponse<FavorisDto>>> AddPiecetoFavoris(int pieceId)
        {
            try
            {
                string userId = await _customCetToken.GetSub();
                ServiceResponse<FavorisDto> response = await _businessFavoris.AddToFavoris(userId,pieceId);
                if (!response.Success)
                {
                    return BadRequest(response.Message);
                }
                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        /// <summary>
        /// add a piece to favorite
        /// </summary>
        /// <param name="favorisId"></param>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpDelete("deletefavoris/{pieceId}")]
        public async Task<ActionResult<ServiceResponse<FavorisDto>>> DeletePiecetoFavoris(int pieceId)
        {
            try
            {
                string userId = await _customCetToken.GetSub();
                ServiceResponse<FavorisDto> response = await _businessFavoris.DeleteFromFavoris(userId, pieceId);
                if (!response.Success)
                {
                    return BadRequest(response.Message);
                }
                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        /// <summary>
        /// getting the favoris
        /// </summary>
        /// <param name="favorisId"></param>
        /// <returns></returns>
        [HttpGet("{page}")]
        public async Task<ActionResult<Pagination<PieceDto>>> GetFavorisById(int page) 
        {
            try
            {
                string userId = await _customCetToken.GetSub();
                Pagination<PieceDto> response = await _businessFavoris.PaginateFavoris(userId,page);
              
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
