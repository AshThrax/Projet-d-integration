using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Publication
{
    [Route("api/[controller]")]
    [ApiController]
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
                return Ok( await _publicationBl.GetAllPublication());
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
                return Ok(await _publicationBl.GetPublicationById(publicationId));
            
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("publication-by-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPublicationByUser()
        {
            try
            {
                var auth = await _customGetToken.GetSub();
                return Ok(await _publicationBl.GetAllbyPublicationByUserId(auth));
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
                await _publicationBl.DeletePublication(publicationById);
                return NoContent();
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
        public async Task<ActionResult> UpdatePublication(string publicationById,string Title, string Content)
        {
            try
            {
                if(Content == null)
                {
                    return BadRequest();
                }
                await _publicationBl.UpdatePublication(publicationById,Title,Content);
                return NoContent(); 
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
        public async Task<ActionResult> CreatePublication( [FromBody] AddPublicationDto AddPublication)
        {
            try
            {
                if (AddPublication == null)
                {
                    return BadRequest();
                }
                string UserId = await _customGetToken.GetSub();
                AddPublication.UserId = UserId;
                await _publicationBl.CreatePublication(AddPublication);
                return NoContent();
            }
            catch 
            {
                return NoContent();
            }

        }
    }
}
