using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogueService _catalogueService;
        public CatalogueController(ICatalogueService catalogueService) 
        {
            _catalogueService = catalogueService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogueDto>> GetbyId([FromBody] int id)
        {
            var entities =await _catalogueService.GetById(id);
            return Ok(entities);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogueDto>>> GetAll()
        {
            var entities = await _catalogueService.GetAll();
            return  Ok(entities);   
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CatalogueDto catalogue)
        { 
            if(catalogue == null)
                throw new ArgumentNullException(nameof(catalogue));
            else
            {
                _catalogueService.Add(catalogue);
                return Ok();
                
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CatalogueDto>> Update([FromBody]int id,[FromBody] CatalogueDto Updtcatalogue)
        {
            if (Updtcatalogue == null)
            {
                BadRequest();
            }
               _catalogueService.Update(Updtcatalogue);
            return await _catalogueService.GetById(Updtcatalogue.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody]int id)
        {
            await _catalogueService.Delete(id);
            return Ok();
        }
    }
}
