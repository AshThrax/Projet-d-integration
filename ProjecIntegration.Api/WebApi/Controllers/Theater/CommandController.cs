﻿using WebApi.Validator;
using ApplicationTheather.Common.Interfaces.IRepository;
using Domain.Entity.TheatherEntity;
using ApplicationTheather.Common.Exceptions;
using ApplicationTheather.DTO;
using ApplicationPublication.Dto;

namespace WebApi.Controllers.Theater
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepository _commandService;
        private readonly IMapper _mapper;
        private readonly ICustomGetToken gtk;
        public CommandController(
            ICommandRepository commandService,
            IMapper mapper,
            ICustomGetToken gtk
            )
        {
            this.gtk = gtk;
            _commandService = commandService;
            _mapper = mapper;
        }
        [HttpGet("get-auth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAuth()
        {
            try
            {
                string subClaim = await gtk.GetSub();
                string MailClaim = await gtk.GetEmail();
                return Ok(subClaim);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommandDto>> GetByid(int id)
        
        {
            try
            {
                var entities = _mapper.Map<Command, CommandDto>(await _commandService.GetById(id));
                return Ok(entities);

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("get-command-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommandDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommandDto>> GetByUser()
        {
            try
            {
                var auth0UserId = gtk.GetSub().Result;

                var entities = _mapper.Map<IEnumerable<CommandDto>>(await _commandService.GetAllUserCommand(auth0UserId));
                return Ok(entities);

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("get-piece/{idPiece}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommandDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Command>>> GetByPiece(int idPiece)
        {
            try
            {
                var entities = _mapper.Map<IEnumerable<CommandDto>>
                    (await _commandService.GetAllFromPiece(idPiece));
                return Ok(entities);

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommandDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CommandDto>>> GetAll()
        {
            try
            {
                var entities = _mapper.Map<IEnumerable<CommandDto>>(await _commandService.GetAll());
                return Ok(entities);

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddCommandDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create([FromBody] AddCommandDto CmdDtot)
        {
            try
            {
                //verifier la validiter des commande
                var validator = new AddCommandValidator();
                var auth0 = await gtk.GetSub();
                CmdDtot.AuthId = auth0;
                if (CmdDtot == null)
                {
                    BadRequest();
                }
                //generation du ticket

                var conversion = _mapper.Map<Command>(CmdDtot);
                _commandService.Insert(conversion);
                return Ok("Create Command");

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{updtId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCommand(int updtId, [FromBody] UpdateCommandDto updtdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                var conversion = _mapper.Map<UpdateCommandDto, Command>(updtdto);
                _commandService.Update(updtId, conversion);
                return Ok();

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                _commandService.Delete(id);
                return Ok("Command Deleted SuccesFully");

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}