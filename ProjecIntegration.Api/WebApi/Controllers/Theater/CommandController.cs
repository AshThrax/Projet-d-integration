using WebApi.Application.DTO;
using WebApi.Application.Common.Exceptions;
using WebApi.Validator;
using ApplicationTheather.Common.Interfaces.IRepository;
using Domain.Entity.TheatherEntity;

namespace WebApi.Controllers.Theater
{

    [Route("api/[controller]")]
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
            try
            {
                var entities = _mapper.Map<Command, CommandDto>(await _commandService.GetById(id));
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
        [HttpGet("get-command-user")]
        public async Task<ActionResult<CommandDto>> GetByUser()
        {
            try
            {
                var auth0UserId = gtk.GetSub().Result;

                var entities = _mapper.Map<IEnumerable<CommandDto>>(await _commandService.GetAllUserCommand(auth0UserId));
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
                var entities = _mapper.Map<IEnumerable<CommandDto>>(await _commandService.GetAll());
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
        public async Task<ActionResult> UpdateCommand(int updtId, [FromBody] UpdateCommandDto updtdto)
        {
            try
            {
                if (updtdto == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<UpdateCommandDto, Command>(updtdto);
                _commandService.Update(updtId, conversion);
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
