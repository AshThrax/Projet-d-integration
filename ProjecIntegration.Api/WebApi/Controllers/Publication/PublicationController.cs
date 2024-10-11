using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Dto;
using Azure;
using Domain.DataType;
using Domain.Entity.publicationEntity;
using Domain.ServiceResponse;
using InfraPublication.BusinessLayer;
using Microsoft.AspNet.SignalR.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApi.Validator.Publication;
using WebApi.Validator.Theather;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationBl _publicationBl;
        private readonly ICustomGetToken _customGetToken;   
        private readonly ILogger<PublicationController> logger;

        public PublicationController(IPublicationBl publicationBl, ICustomGetToken customGetToken, ILogger<PublicationController> logger)
        {
            this._publicationBl = publicationBl;
            _customGetToken = customGetToken;   
            this.logger = logger;
        }

        [HttpGet("publication-all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllPublication()
        {
            try
            {
                ServiceResponse<IEnumerable<PublicationDto>> response = await _publicationBl.GetAllPublication();
                return Ok( response);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("publication-by-id/{publicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPublicationById(string publicationId)
        {
            try
            {
                ServiceResponse<PublicationDto> response = await _publicationBl.GetPublicationById(publicationId);
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
              
            
            }
            catch
            {
                return NotFound();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        [HttpGet("by-piece/{page}/{pieceId}")]
        public async Task<ActionResult> GetpublicationByPieceId(int page,int pieceId)
        {
            try
            {
                ServiceResponse<IEnumerable<PublicationDto>> response= (await _publicationBl.GetPublicationByPiece(pieceId));
                if (response.Success)
                {
                    Pagination<PublicationDto> pagePublication = Pagination<PublicationDto>.ToPagedList(response.Data.ToList(), page, 5);
                    return Ok(pagePublication);
                }
                else
                {
                    return BadRequest(response);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("publication-by-user/{page}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPublicationByUser(int page)
        {
            try
            {
                var auth = await _customGetToken.GetSub();
                ServiceResponse<IEnumerable<PublicationDto>> response= await _publicationBl.GetAllbyPublicationByUserId(auth);
                if (response.Success)
                {
                  
                    Pagination<PublicationDto> pagePublication = Pagination<PublicationDto>.ToPagedList(response.Data.ToList(), page, 5);
                    return Ok(pagePublication);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("publication-by-user/{userId}/{page}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPublicationByUser(string userId,int page)
        {
            try
            {
               
                ServiceResponse<IEnumerable<PublicationDto>> response = (await _publicationBl.GetAllbyPublicationByUserId(userId));
                if (response.Success)
                {
                    Pagination<PublicationDto> pagePublication = Pagination<PublicationDto>.ToPagedList(response.Data.ToList(), page, 5);
                    return Ok(pagePublication);
                }
                else 
                {
                    return BadRequest(response);
                }
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete("delete-publication/{publicationById}")]
        public async Task<ActionResult> DeletePublication(string publicationById)
        {
            try
            {
                ServiceResponse<PublicationDto>response= await _publicationBl.DeletePublication(publicationById);
                if (response.Success)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(response);
                }
                
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut("update-publication/{publicationById}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePublication(string publicationById,[FromBody] UpdatePublicationDto publication)
        {
            try
            {
                if(publicationById == null)
                {
                    return BadRequest();
                }
                var Validator = new UpdatePublicationValidator();
                var result = Validator.Validate(publication);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }
                ServiceResponse<PublicationDto> response =await _publicationBl.UpdatePublication(publicationById,publication.Title,publication.Review);
                if (response.Success)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch
            {
                return NotFound();

            }
        }
        [HttpPost("create-publication")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddPublicationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreatePublication( [FromBody] AddPublicationDto addPublication)
        {
            try
            {
                if (addPublication == null)
                {
                    return BadRequest();
                }
                var Validator = new AddPublicationValidator();
                var result = Validator.Validate(addPublication);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }
                string UserId = await _customGetToken.GetSub();
                addPublication.UserId = UserId;
               
                ServiceResponse<PublicationDto> response= await _publicationBl.CreatePublication(addPublication);
                if (response.Success)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch 
            {
                return NoContent();
            }

        }
        [HttpGet("iswriter/{publicationId}")]
        public async Task<ActionResult> IsAuthor(string publicationId)
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                bool iswriter = await _publicationBl.IsAuthor(publicationId, userId);
                return Ok(iswriter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("hasreview/{pieceId}")]
        public async Task<ActionResult>  HasReview(int pieceId)
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                bool Hasreview = await _publicationBl.Hasreview(pieceId, userId);
                return Ok(Hasreview);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
