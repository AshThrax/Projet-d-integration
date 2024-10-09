using ApplicationTheather.Common.Exceptions;
using Azure;
using Domain.DataType;
using Domain.ServiceResponse;
using Microsoft.AspNet.SignalR.Hosting;

namespace WebApi.Controllers.Theater
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CommandController : ControllerBase
    {
        private readonly IBusinessCommandService _commandService;
        private readonly IMapper _mapper;
        private readonly ICustomGetToken gtk;
        public CommandController(
            IBusinessCommandService commandService,
            IMapper mapper,
            ICustomGetToken gtk
            )
        {
            this.gtk = gtk;
            _commandService = commandService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommandDto>> GetById(int id)
        
        {
            try
            {
                ServiceResponse<CommandDto> response= await _commandService.GetCommand(id);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);

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
        [HttpGet("get-command-user/{page}")]
     
        public async Task<ActionResult<Pagination<CommandDto>>> GetByUser(int page)
        {
            try
            {
                var auth0UserId = gtk.GetSub().Result;
                ServiceResponse<IEnumerable<CommandDto>> response = (await _commandService.GetCommandUSer(auth0UserId));
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<CommandDto> pageCommande = Pagination<CommandDto>.ToPagedList(response.Data.ToList(), page, 10);
                return Ok(pageCommande);

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
        [HttpGet("get-piece/{idPiece}/{page}")]
    
        public async Task<ActionResult<Pagination<CommandDto>>> GetByPiece(int idPiece, int page)
        {
            try
            {
                ServiceResponse<IEnumerable<CommandDto>> response = await _commandService.GetCommandByPiece(idPiece);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<CommandDto> pageCommande = Pagination<CommandDto>.ToPagedList(response.Data.ToList(), page, 10);
                return Ok(pageCommande);

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
        public async Task<ActionResult<ServiceResponse<IEnumerable<CommandDto>>>> GetAll()
        {
            try
            {
                ServiceResponse<IEnumerable<CommandDto>> response = await _commandService.GetAllCommand();
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);

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
     
        public async Task<ActionResult> Create([FromBody] AddCommandDto CmdDtot)
        {
            try
            {
                //verifier la validiter des commande
                var validator = new AddCommandValidator();
                var auth0 = await gtk.GetSub();
                CmdDtot.AuthId = auth0;
                if (!ModelState.IsValid)
                {
                    BadRequest();
                }
                ServiceResponse<CommandDto> response= await _commandService.AddCommand(CmdDtot);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
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
       
        public async Task<ActionResult> UpdateCommand(int updtId, [FromBody] UpdateCommandDto updtdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
              
               ServiceResponse<CommandDto> response=  await _commandService.UpdateCommand(updtId,updtdto);
                if (!response.Success)
                {
                    
                }
                return Ok(response);

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
       
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                ServiceResponse<CommandDto> response =await _commandService.DeleteCommand(id);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
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
        [HttpGet("exist/{pieceid}")]
        public async Task<ActionResult<bool>> DoIHaveACommand(int pieceid) 
        {
            try
            {
                string userId = await gtk.GetSub();
                ServiceResponse<bool> response= await _commandService.VerifiedCommand(pieceid, userId);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else 
                {
                    return BadRequest(response.Message);
                }
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
