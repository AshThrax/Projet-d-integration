using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.complexe;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexeController : ControllerBase
    {
        private readonly IComplexeRepository _complexeService;

        public ComplexeController(IComplexeRepository complexeService)
        {
            _complexeService = complexeService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromBody] int id)
        {
            try
            {
                var entity= await _complexeService.GetById(id);
                return Ok(entity);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplexeDto>>> GetAll()
        {
            try
            {
                var entity = await _complexeService.GetAll();
                return Ok(entity);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ComplexeDto complexe)
        {
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                _complexeService.Add(complexe);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int updtId,[FromBody] ComplexeDto complexe)
        {
            try
            {
                if (complexe == null)
                {
                    BadRequest();
                }
                _complexeService.Update(updtId,complexe);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete( int id)
        {
            try
            {
                var entity = await _complexeService.GetById(id);
                _complexeService.Delete(entity);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
    }
}
