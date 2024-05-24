using ApplicationTheather.BusinessService;
using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Theater
{
    [Route("api/[controller]")]
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
                return Ok(await _businessCatalogue.GetCatalogueByComplexe(complexeId));
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
              return Ok(await _businessCatalogue.GetCatalogueById(catalogueId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{catalogueId}")]
        public async Task<ActionResult<CatalogueDto>> UpdateCatalogues(int catalogueId, [FromBody] UpdateCatalogueDto updtCatalogue)
        {
            try
            {
                await _businessCatalogue.UpdateCatalogue(catalogueId, updtCatalogue);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{catalogueId}")]
        public async Task<ActionResult<CatalogueDto>> DeleteCatalogue(int catalogueId)
        {
            try
            {
                await _businessCatalogue.DeleteCatalogue(catalogueId);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
