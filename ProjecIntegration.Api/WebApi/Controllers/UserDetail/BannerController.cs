using ApplicationUser.BusinessService.Banner;
using ApplicationUser.Dto;
using Domain.ServiceResponse;
using WebApi.ApiService.FileService;

namespace WebApi.Controllers.UserDetail
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {

        private readonly ILogger<BannerController> _logger;
        private readonly ICustomGetToken _customGetToken;
        private readonly IFileService _fileService;
        private readonly IBannerService _bannerService;

        public BannerController(ILogger<BannerController> logger,
                                IBannerService bannerService,
                                ICustomGetToken customGetToken,
                                IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
            _customGetToken = customGetToken;
            _bannerService = bannerService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<BannerDto>>> AddBanner(IFormFile files)
        {
            try
            {
                string userId = await  _customGetToken.GetSub();
                //---
                if (files.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await _fileService.SaveFileAsync(files, allowedFileExtentions);

                ServiceResponse<BannerDto> response= await _bannerService.AddBanner(userId, createdImageName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        /// <summary>
        /// get user banner
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<BannerDto>>> GetBanner()
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                ServiceResponse<BannerDto> response = await _bannerService.HasBanner(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        /// <summary>
        /// get user banner
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        [HttpGet("{userId}")]
        public async Task<ActionResult<ServiceResponse<BannerDto>>> GetBanner(string userId)
        {
            try
            {
                
                ServiceResponse<BannerDto> response = await _bannerService.HasBanner(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<ServiceResponse<BannerDto>>> UpdateBanner(IFormFile files)
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                //---
                if (files.Length > 1 * 1200 * 2400)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await _fileService.SaveFileAsync(files, allowedFileExtentions);
                ServiceResponse<BannerDto> response = await _bannerService.UpdateBanner(userId,createdImageName);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BannerDto>>> UpdateProfileBanner(IFormFile files)
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                //---
                if (files.Length > 1 * 1200 * 2400)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await _fileService.SaveFileAsync(files, allowedFileExtentions);
                ServiceResponse<BannerDto> response = await _bannerService.UpdateBanner(userId, createdImageName);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{ex.Message}");
            }
        }
    }
}
