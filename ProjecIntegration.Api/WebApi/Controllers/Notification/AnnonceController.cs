using ApplicationAnnonce.Common.businessService;
using ApplicationAnnonce.DTO;
using ApplicationPublication.Dto;
using Domain.Entity.notificationEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
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

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAnnonceDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll([FromQuery]int pageNumber)
        
        {
            try
            {
                return Ok(await annonceBl.GetAnnonces(pageNumber));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{annonceId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAnnonceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(string annonceId) 
        {
            try
            { 
                return Ok(await annonceBl.GetAnnonceById(annonceId));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddAnnonceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateAnnonce([FromBody] AddAnnonceDto annonce)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await annonceBl.CreateAnnonce(annonce);
                   
                    
                } 
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{annonceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAnnonce(string annonceId,[FromBody] UpdateAnnonceDto? annonce)
        {
            try
            {
                if (ModelState.IsValid)
                {  
                    await annonceBl.UpdateAnnonce(annonceId,annonce);
                    return NoContent();
                }

                return BadRequest();
              
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{annonceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAnnonce(string annonceId)
        {
            try 
            { 
                await annonceBl.DeleteAnnonce(annonceId);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
