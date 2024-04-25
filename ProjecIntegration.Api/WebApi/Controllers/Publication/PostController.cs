using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Dto;
using InfraPublication.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Publication
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBL postBL;
        private readonly ILogger<PostController> logger;

        public PostController(IPostBL postBL, ILogger<PostController> logger)
        {
            this.postBL = postBL;
            this.logger = logger;
        }
        [HttpGet("publication-all/{publicationId}")]
        public async Task<ActionResult> GetAllPostFromPublication(string publicationId)
        {
            try
            {
                var GetPost = await postBL.GetAllPostFromPUblicationId(publicationId);
                return Ok(GetPost);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("publication-by-id/{postById}")]
        public async Task<ActionResult> GetPostById(string postById)
        {
            try
            {
                var GetPost= await postBL.GetPostById(postById);
                return Ok(GetPost);
            }
            catch (Exception ex)
            {
               return NotFound();
            }
        }
        [HttpDelete("delete-publication/{postById}")]
        public async Task<ActionResult> DeletePostFromPublication(string postById)
        {
            try
            {
                var GetPost =  postBL.DeletePost(postById);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPut("update-publication/{publicationById}")]
        public async Task<ActionResult> UpdatePostfromPublication(string postById,string content)
        {
            try
            {
                if (content == null)
                {
                    return BadRequest();
                }
               await postBL.UpdatePost(postById, content);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost("create-publication/{publicationById}")]
        public async Task<ActionResult> createPublication(string publicationById, [FromBody] PostDto AddPost)
        {
            try
            {
                if (AddPost == null)                  
                {
                    return BadRequest();
                }
                    await postBL.Createasync(publicationById,AddPost);
                    return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
    }
}
