using Domain.Entity;
using Domain.ServiceResponse;
using ApplicationUser.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneriqueController<TEntity, TDto, TAddDto, TUpdateDto> : ControllerBase
        where TEntity : BaseEntity
        where TDto : BasicDto
        where TAddDto : AddBaseDto
        where TUpdateDto : UpdateUserDetailDto
    {
        private readonly IService<TEntity, TDto, TAddDto, TUpdateDto> _service;

        public GeneriqueController(IService<TEntity, TDto, TAddDto, TUpdateDto> service)
        {
            _service = service;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<TDto>>> GetById(int Id)
        {
            try
            {
                ServiceResponse<TDto> response = await _service.GetByIdAsync(Id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet()]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> GetAll()
        {
            try
            {
                ServiceResponse<List<TDto>> response = await _service.GetAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> AddAsync([FromBody] TAddDto AddDto)
        {
            try
            {
                ServiceResponse<TDto> response = await _service.AddAsync(AddDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{updtId}")]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> AddAsync(int updtId,[FromBody] TUpdateDto AddDto)
        {
            try
            {
                ServiceResponse<TDto> response = await _service.UpdateAsync(updtId,AddDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> AddAsync(int Id)
        {
            try
            {
                ServiceResponse<TDto> response = await _service.DeleteAsync(Id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
