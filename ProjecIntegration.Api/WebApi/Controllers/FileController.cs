using ApplicationTheather.DTO;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.ApiService.FileService;
using WebApi.ApiService.UploadResult;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        
        private readonly ILogger<FileController> _logger;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ApplicationDbContext _context;

        public FileController(IFileService fileService, ApplicationDbContext context,IMapper mapper, ILogger<FileController> logger)
        {
            _mapper = mapper;
            _fileService = fileService;
            _context = context;
            _logger = logger;
        }

      
      
        [HttpPost]
        public async Task<ActionResult<ImageDto>> UploadFile(IFormFile files)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();

            
                if (files.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await _fileService.SaveFileAsync(files, allowedFileExtentions);

                ImageDto newImage= new ImageDto() {ImageRessource = createdImageName};
                Image AddImage= _mapper.Map<Image>(newImage);
                var added= _context.Image.Add(AddImage).Entity;
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<ImageDto>(added));
           
        }
    }
}
