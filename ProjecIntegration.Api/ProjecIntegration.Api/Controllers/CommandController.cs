﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.ApiService;
using ProjecIntegration.Api.Application.Common.Exception;
using ProjecIntegration.Api.Application.Common.Exceptions;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO;
using System.Security.Claims;

namespace ProjecIntegration.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
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
            this.gtk=gtk;
            _commandService = commandService;
            _mapper = mapper;
        }
        [HttpGet("get-auth")]
        public async Task<ActionResult> GetAuth()
        {
            try
            {
                var subClaim = await gtk.GetSub();
                var MailClaim = await gtk.GetEmail();
                return Ok(subClaim);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CommandDto>> GetByid(int id)
        {
            try { 
                var entities = _mapper.Map<Command,CommandDto>(await _commandService.GetById(id));
                return Ok(entities);
            
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpGet("get-command-user/{id}")]
        public async Task<ActionResult<CommandDto>> GetByUser()
        {
            try
            {
                var auth0UserId = gtk.GetSub().Result; 

                var entities = _mapper.Map<IEnumerable<CommandDto>> (await _commandService.GetAllUserCommand(auth0UserId));
                return Ok(entities);

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("get-piece/{idPiece}")]
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
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandDto>>> GetAll()
        {
            try
            {
                var entities = _mapper.Map<IEnumerable <CommandDto>>(await _commandService.GetAll());
                return Ok(entities);

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddCommandDto CmdDtot)
        {
            try
            {
                var auth0 = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                CmdDtot.AuthId = auth0;
                if (CmdDtot == null)
                {
                    BadRequest();
                }
                var conversion= _mapper.Map<Command>(CmdDtot);
                 _commandService.Insert(conversion);
                return Ok("Create Command");

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
       
        [HttpPut("{updtId}")]
        public async Task<ActionResult> Update(int updtId,[FromBody] UpdateCommandDto updtdto)
        {
            try
            {
                if (updtdto == null)
                {
                    BadRequest(); 
                }
                var conversion = _mapper.Map<UpdateCommandDto, Command>(updtdto);
                _commandService.Update(updtId,conversion);
                return Ok();

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
              
               _commandService.Delete(id);
                return Ok("Command Deleted SuccesFully");

            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "");
            }
        }
    }
}
