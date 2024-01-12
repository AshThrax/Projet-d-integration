using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.command;
using ProjecIntegration.Api.Application.DTO.ticket;
using System.Collections.Generic;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepository _commandService;
        private readonly IMapper _mapper;

        public CommandController(ICommandRepository commandService, IMapper mapper)
        {
            _commandService = commandService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommandDto>> GetByid([FromBody] int id)
        {
            try { 
                var entities = _mapper.Map<Command,CommandDto>(await _commandService.GetById(id));
                return Ok(entities);
            
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("{id}/get-command-user")]
        public async Task<ActionResult<CommandDto>> GetByuser()
        {
            try
            {
                var entities = _mapper.Map<IEnumerable<Command>, IEnumerable<CommandDto>> (await _commandService.GetAllUserCommand());
                return Ok(entities);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandDto>>> GetAll()
        {
            try
            {
                var entities = _mapper.Map< IEnumerable < Command> ,IEnumerable <CommandDto>>(await _commandService.GetAll());
                return Ok(entities);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CommandDto CmdDtot)
        {
            try
            {
                var auth0 = HttpContext.User.FindFirst("sub")?.Value;
                CmdDtot.AuthId = auth0;
                if (CmdDtot == null)
                {
                    BadRequest();
                }
                await _commandService.Add(CmdDtot);
                return Ok("Create Command");

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost("{commandid}/add-ticket")]
        public async Task<IActionResult> AddTicketToCommand(int commandid, [FromBody] TicketsDto ticket)
        {
            try
            {
                _commandService.AddTicketToCommand(commandid, ticket);
                return Ok("Ticket added to the command successfully.");

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(int updtId,[FromBody] CommandDto updtdto)
        {
            try
            {
                if (updtdto == null)
                {
                    BadRequest(); 
                }
                _commandService.Update(updtId,updtdto);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cmd = await _commandService.GetById(id);
               _commandService.Delete(cmd);
                return Ok("Command Deleted SuccesFully");

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
    }
}
