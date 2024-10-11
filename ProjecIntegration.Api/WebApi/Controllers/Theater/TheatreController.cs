namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreBusiness _theatreBusiness;
        private readonly ILogger<TheatreController> logger;

        public TheatreController(ITheatreBusiness theatreBusiness, ILogger<TheatreController> logger)
        {
            _theatreBusiness = theatreBusiness;
            this.logger = logger;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ThemeDto>>> GetAllTheme() 
        {
            try
            {
                return Ok(await _theatreBusiness.GetAllTheme());
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{themeId}")]
        public async Task<ActionResult<ThemeDto>> GetThemeById(int themeId)
        {
            try
            {
                return Ok(await _theatreBusiness.GetThemeById(themeId));
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpPost("")]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult<ThemeDto>> CreateTheme([FromBody] ThemeDto theme)
        {
            try
            {
                if(!ModelState.IsValid) 
                {
                    return BadRequest();
                }

                await _theatreBusiness.CreateTheme(theme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpPut("")]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult<ThemeDto>> UpdateTheme(int themeId, [FromBody] ThemeDto theme)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _theatreBusiness.UpdateTheme(themeId, theme);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("")]
        [Authorize(Roles=("Admin"))]
        public async Task<ActionResult<ThemeDto>> DeleteTheme(int themeId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _theatreBusiness.Deletetheme(themeId);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
