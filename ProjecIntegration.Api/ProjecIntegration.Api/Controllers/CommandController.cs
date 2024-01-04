using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandService _commandService;

        public CommandController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommandDto>> GetByid([FromBody] int id)
        {
            var entities = await _commandService.GetById(id);
            return Ok(entities);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandDto>>> GetAll()
        {
            var entities = await _commandService.GetAll();
            return Ok(entities);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CommandDto CmdDtot)
        {
            if (CmdDtot == null)
            {
                BadRequest();
            }
                await _commandService.Add(CmdDtot);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CommandDto updtdto)
        {
            if (updtdto == null)
            {
                BadRequest(); 
            }
            _commandService.Update(updtdto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] CommandDto commandDto)
        {
           _commandService.Delete(commandDto);
            return Ok();
        }
    }
}
