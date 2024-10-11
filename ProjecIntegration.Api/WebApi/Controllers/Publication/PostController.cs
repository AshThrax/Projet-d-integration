using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Dto;
using Domain.DataType;
using Domain.ServiceResponse;
using InfraPublication.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Validator.Publication;
using WebApi.Validator.Theather;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
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
                ServiceResponse<IEnumerable<PostDto>> GetPost = await postBL.GetAllPostFromPublicationId(publicationId);
                if (GetPost.Success)
                {
                    Pagination<PostDto> PagePost = Pagination<PostDto>.ToPagedList(GetPost.Data.ToList(), page, 5);
                    return Ok(PagePost);

                }
                else 
                {
                    return BadRequest(GetPost);
                }
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
                ServiceResponse<IEnumerable<PostDto>> GetPost = await postBL.GetPostFromUserId(publicationId);
                if (GetPost.Success)
                {
                    return Ok(GetPost);
                }
                else
                {
                    return BadRequest(GetPost);
                }
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
                ServiceResponse<PostDto> response=  await postBL.DeletePost(postById);
                if (response.Success)
                {
                    return Ok(response);
                }
                else 
                {
                    return BadRequest(response);
                }
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
        public async Task<ActionResult> UpdatePostfromPublication(string postById, [FromBody] UpdatePostDto updtPost)
        {
            try
            {
               
                var Validator = new UpdatePostValidator();
                var result = Validator.Validate(updtPost);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }

               
                ServiceResponse<PostDto> response= await postBL.UpdatePost(postById,updtPost.Content);
                if (response.Success)
                {
                    return Ok(response);
                }
                else 
                {
                    return BadRequest(response);
                }
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
        public async Task<ActionResult> CreatePublication(string publicationById, [FromBody] AddPostDto addPost)
        {
            try
            {
                if (addPost == null)                  
                {
                    return BadRequest();
                }
                var Validator = new AddPostValidator();
                var result = Validator.Validate(addPost);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }
                addPost.UserId = await _customGetToken.GetSub();
                addPost.PublicationId=publicationById;
                ServiceResponse<PostDto> response= await postBL.CreateAsync(publicationById,addPost);
                
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
              
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
