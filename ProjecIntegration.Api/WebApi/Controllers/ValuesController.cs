using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet]
        public  IActionResult Get()
        {
            string message = "authentification configured";
            return Ok(message);
        }
        [HttpGet("map")]
        [Authorize]
        public IActionResult Gette()
        {
            return Ok("authentification configured");
        }
    }
}
