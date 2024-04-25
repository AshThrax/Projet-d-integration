using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Dto;
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
        public async Task<ActionResult> GetPublicationByUser(string publicationId)
        {
            try
            {
                var auth = await _customGetToken.GetSub();
                return Ok(await _publicationBl.GetAllbyPublicationID(auth));
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
        public async Task<ActionResult> UpdatePublication(string publicationById,string Content)
        {
            try
            {
                if(Content == null)
                {
                    return BadRequest();
                }
                await _publicationBl.UpdatePublication(publicationById,Content);
                return NoContent(); 
            }
            catch
            {
                return NotFound();

            }
        }
        [HttpPost("create-publication/{publicationById}")]
        public async Task<ActionResult> CreatePublication( [FromBody] PublicationDto AddPublication)
        {
            try
            {
                if (AddPublication == null)
                {
                    return BadRequest();
                }
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
