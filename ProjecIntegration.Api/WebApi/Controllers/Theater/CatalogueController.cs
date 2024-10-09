using Azure;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;
using Microsoft.AspNet.SignalR.Hosting;

namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly IBusinessCatalogue _businessCatalogue;

        public CatalogueController(IBusinessCatalogue businessCatalogue)
        {
            _businessCatalogue = businessCatalogue;
        }
       
        [HttpGet("complexe/{complexeId}")]
        public async Task<ActionResult<IEnumerable<CatalogueDto>>> GetCatalogues(int complexeId)
        {
            try
            {
                ServiceResponse<IEnumerable<CatalogueDto>>response= (await _businessCatalogue.GetCatalogueByComplexe(complexeId));
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(Response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogueDto>>> GetAll()
        {
            try
            {
                ServiceResponse<IEnumerable<CatalogueDto>> response = await _businessCatalogue.GetAllCatalogue();
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{catalogueId}")]
        public async Task<ActionResult<CatalogueDto>> GetCataloguesById(int catalogueId)
        {
            try
            {
                ServiceResponse<CatalogueDto> response = await _businessCatalogue.GetCatalogueById(catalogueId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpPut("{catalogueId}")]
        public async Task<ActionResult<CatalogueDto>> UpdateCatalogues(int catalogueId, [FromBody] UpdateCatalogueDto updtCatalogue)
        {
            try
            {
               ServiceResponse<CatalogueDto> response = await _businessCatalogue.UpdateCatalogue(catalogueId, updtCatalogue);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpDelete("{catalogueId}")]
        public async Task<ActionResult<CatalogueDto>> DeleteCatalogue(int catalogueId)
        {
            try
            {
               ServiceResponse<CatalogueDto> response= await _businessCatalogue.DeleteCatalogue(catalogueId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
    }
}
