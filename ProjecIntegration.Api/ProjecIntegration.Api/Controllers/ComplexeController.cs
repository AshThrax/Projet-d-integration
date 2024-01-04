using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexeController : ControllerBase
    {
        private readonly IComplexeService _complexeService;

        public ComplexeController(IComplexeService complexeService)
        {
            _complexeService = complexeService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromBody] int id)
        {
            var entity= await _complexeService.GetById(id);
            return Ok(entity);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplexeDto>>> GetAll()
        {
            var entity = await _complexeService.GetAll();
            return Ok(entity);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ComplexeDto complexe)
        {
            if (complexe == null)
            {
                BadRequest();
            }
            _complexeService.Add(complexe);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] ComplexeDto complexe)
        {
            if (complexe == null)
            {
                BadRequest();
            }
            _complexeService.Update(complexe);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            _complexeService.Delete(id);
            return NoContent();
        }
    }
}
