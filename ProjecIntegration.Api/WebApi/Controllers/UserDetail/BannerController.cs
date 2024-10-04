﻿using ApplicationUser.BusinessService;
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
        [HttpPost]
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
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{bannerId}")]
        public async Task<ActionResult<ServiceResponse<BannerDto>>> UpdateBanner(int bannerId,IFormFile file)
        {
            try
            {
                string userId = await _customGetToken.GetSub();
                //---
                if (file.Length > 1 * 1200 * 2400)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await _fileService.SaveFileAsync(file, allowedFileExtentions);
                ServiceResponse<BannerDto> response = await _bannerService.UpdateBanner(bannerId,createdImageName);
                return Ok(response);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
