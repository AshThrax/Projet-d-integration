using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Dto;
using Domain.DataType;
using InfraPublication.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBL postBL;
        private readonly ICustomGetToken _customGetToken;
        private readonly ILogger<PostController> logger;

        public PostController(IPostBL postBL,ICustomGetToken customGetToken, ILogger<PostController> logger)
        {
            this.postBL = postBL;
            this.logger = logger;
            _customGetToken=customGetToken;
        }
        [HttpGet("publication-all/{publicationId}/{page}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(IEnumerable<PostDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<PostDto>>> GetAllPostFromPublication(string publicationId,int page)
        {
            try
            {
                IEnumerable<PostDto> GetPost = await postBL.GetAllPostFromPublicationId(publicationId);
                Pagination<PostDto> PagePost = Pagination<PostDto>.ToPagedList(GetPost.ToList(), page, 5);
                return Ok(PagePost);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("user/{publicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllPostFromUser(string publicationId)
        {
            try
            {
                IEnumerable<PostDto> GetPost = await postBL.GetPostFromUserId(publicationId);
                return Ok(GetPost);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{postById}")]
        public async Task<ActionResult> GetPostById(string postById)
        {
            try
            {
                var GetPost= await postBL.GetPostById(postById);
                return Ok(GetPost);
            }
            catch (Exception ex)
            {
               return NotFound(ex.Message);
            }
        }
        [HttpDelete("{postById}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePostFromPublication(string postById)
        {
            try
            {
                  await postBL.DeletePost(postById);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{publicationById}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePostfromPublication(string postById,string content)
        {
            try
            {
                if (content == null)
                {
                    return BadRequest("conent null");
                }
               await postBL.UpdatePost(postById, content);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{publicationById}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePublication(string publicationById, [FromBody] AddPostDto AddPost)
        {
            try
            {
                if (AddPost == null)                  
                {
                    return BadRequest();
                }
                AddPost.UserId = await _customGetToken.GetSub();
                AddPost.PublicationId=publicationById;
                await postBL.CreateAsync(publicationById,AddPost);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet("iswriter/{postId}")]
        public async Task<ActionResult> IsAuthor(string PostId)
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                bool iswriter= await postBL.IsAuthor(PostId,userId);
                return Ok(iswriter);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
