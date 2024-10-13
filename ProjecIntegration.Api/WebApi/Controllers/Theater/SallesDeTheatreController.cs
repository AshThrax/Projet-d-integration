using ApplicationTheather.BusinessService.Salle;
using ApplicationTheather.Common.Exceptions;
using Azure;
using Domain.DataType;
using Domain.ServiceResponse;
using Microsoft.AspNet.SignalR.Hosting;
using WebApi.Validator.Theather;
namespace WebApi.Controllers.Theater;

[Route("api/v1/[controller]")]
[ApiController]
public class SallesDeTheatreController : ControllerBase
{
        private readonly IBusinessSalle _bussinessServices;
      
        private readonly IMapper _mapper;
        public SallesDeTheatreController(IBusinessSalle bussinessServices, IMapper mapper)
        {
            _bussinessServices= bussinessServices;
            _mapper = mapper;
        }
        [HttpGet("single/{id}")]
  
        public async Task<ActionResult<SalleDeTheatreDto>> GetSalleById(int id)
        {
            try
            {
                ServiceResponse<SalleDeTheatreDto> response = await _bussinessServices.GetSalle(id);
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
        [HttpGet("get-complexe/{id}/{page}")]
        public async Task<ActionResult<Pagination<SalleDeTheatreDto>>> GetSalleByComplexe(int id, int page)
        {
            try
            {
                ServiceResponse<IEnumerable<SalleDeTheatreDto>> response= await _bussinessServices.GetFromComplexe(id);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<SalleDeTheatreDto> pageSalle = Pagination<SalleDeTheatreDto>.ToPagedList(response.Data.ToList(), page, 10);
                return Ok(pageSalle);
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
        [HttpGet("{page}")]

        public async Task<ActionResult<Pagination<SalleDeTheatreDto>>> GetAllSalle(int page)
        {
            try
            {
                ServiceResponse<IEnumerable<SalleDeTheatreDto>> response = await _bussinessServices.GetAllSalle();
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<SalleDeTheatreDto> pageSalle = Pagination<SalleDeTheatreDto>.ToPagedList(response.Data.ToList(), page, 10);
                return Ok(pageSalle);

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
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<SalleDeTheatreDto>>> GetAllSallelist()
        {
            try
            {
                ServiceResponse<IEnumerable<SalleDeTheatreDto>> response = await _bussinessServices.GetAllSalle();
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
        [HttpPost("")]
    [Authorize(Roles = ("Admin"))]
    public async Task<ActionResult> CreateSalle([FromBody] AddSalleDeTheatreDto addSalle)
        {
            try
            {
            var Validator = new AddSalleValidator();
            var result = Validator.Validate(addSalle);
            if (!result.IsValid)
            {
                return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
            }
            ServiceResponse<SalleDeTheatreDto> response= await _bussinessServices.CreateSalle(addSalle.ComplexeId,addSalle);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
            return Ok(addSalle);
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
    [Authorize(Roles = ("Admin"))]
    public async Task<ActionResult<SalleDeTheatreDto>> Update(int updtId, [FromBody] UpdateSalleDeTheatreDto updtSalle)
        {
            if (updtId <= 0)
            {
                return BadRequest(updtId);
            }
            try
            {
                var Validator = new UpdtSalleValidator();
                var result = Validator.Validate(updtSalle);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }

            ServiceResponse<SalleDeTheatreDto> response = await _bussinessServices.Updatesalle(updtId,updtSalle);
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
        [HttpDelete("{id}")]
    [Authorize(Roles = ("Admin"))]

    public async Task<ActionResult> DeleteSalle(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            try
            {
                ServiceResponse<SalleDeTheatreDto> response = await _bussinessServices.DeleteSalle(id);
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
     
}


