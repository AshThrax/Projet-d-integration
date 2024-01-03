using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        public CatalogueController() 
        {
            
        }
        [HttpGet("{id}")]
        public CatalogueDto GetbyId([FromBody] int id)
        {
            
        }
        [HttpGet]
        public IEnumerable<CatalogueDto> GetAll()
        {
            
        }
    }
}
