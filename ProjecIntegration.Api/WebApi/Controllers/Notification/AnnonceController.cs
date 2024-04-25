using Application.Common.businessService;
using Application.DTO;
using Domain.Entity.notificationEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace WebApi.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonceController : ControllerBase
    {
        private readonly ILogger<AnnonceController> _logger;
        private readonly IAnnonceBl annonceBl;

        public AnnonceController(ILogger<AnnonceController> logger, IAnnonceBl annonceBl)
        {
            _logger = logger;
            this.annonceBl = annonceBl;
        }

        [HttpGet("get-annonce")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await annonceBl.GetAnnonces());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("get-annonce/{annonceId}")]
        public async Task<ActionResult> GetById(string annonceId) 
        {
            try
            { 
                return Ok(await annonceBl.GetAnnonceById(annonceId));
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost("post-annonce")]
        public async Task<ActionResult> CreateAnnonce([FromBody] AddAnnonceDto annonce)
        {
            try
            {
                await annonceBl.CreateAnnonce(annonce);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("update-annonce/{annonceId}")]
        public async Task<ActionResult> UpdateAnnonce(string annonceId,[FromBody] UpdateAnnonceDto annonce)
        {
            try
            {
                if (annonce ==null)
                {  
                    await annonceBl.UpdateAnnonce(annonceId,annonce);
                    return NoContent();
                }

                return BadRequest();
              
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("supress-annonce/{annonceId}")]
        public async Task<ActionResult> UpdateAnnonce(string annonceId)
        {
            try 
            { 
                await annonceBl.DeleteAnnonce(annonceId);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound();
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
    }
}
