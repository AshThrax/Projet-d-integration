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
        /// Create the favorite 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FavorisDto>>> CreateFavoris()
        {
            try
            {
                string userId =await _customCetToken.GetSub();
                ServiceResponse<FavorisDto> response=await _businessFavoris.CreateFavoris(userId);
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
        [HttpPost("addFavoris/{pieceId}")]
        public async Task<ActionResult<ServiceResponse<FavorisDto>>> AddPiecetoFavoris(int favorisId,int pieceId)
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
