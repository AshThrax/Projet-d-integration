﻿using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Dto;
using InfraPublication.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Publication
{
    [Route("api/v1/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(IEnumerable<PostDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllPostFromPublication(string publicationId)
        {
            try
            {
                IEnumerable<PostDto> GetPost = await postBL.GetAllPostFromPUblicationId(publicationId);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePublication(string publicationById, [FromBody] PostDto AddPost)
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