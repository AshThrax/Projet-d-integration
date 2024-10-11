using Azure;
using Domain.DataType;
using Domain.ServiceResponse;
using Microsoft.AspNet.SignalR.Hosting;
using WebApi.Validator.Theather;

namespace WebApi.Controllers.Theater
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SiegeController : ControllerBase
    {
        private readonly IBusinessSiege _businessSiege;
        private ILogger<SiegeController> logger;

        public SiegeController(IBusinessSiege businessSiege, ILogger<SiegeController> logger)
        {
            _businessSiege = businessSiege;
            this.logger = logger;
        }
        [HttpGet("from-salle/{salleId}/{page}")]
        public async Task<ActionResult<Pagination<SiegeDto>>> GetSiegeFromSalle(int salleId,int Page)
        {
            try
            {
                ServiceResponse<IEnumerable<SiegeDto>> response = await _businessSiege.GetSiegeFromSalleId(salleId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                Pagination<SiegeDto> PageSiege=Pagination<SiegeDto>.ToPagedList(response.Data.ToList(), Page,10);
                return Ok(PageSiege);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("from-salle/{salleId}")]
        public async Task<ActionResult<IEnumerable<SiegeDto>>> GetSiegeFromSalle(int salleId)
        {
            try
            {
                ServiceResponse<IEnumerable<SiegeDto>> response = await _businessSiege.GetSiegeFromSalleId(salleId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("from-command/{commandId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SiegeDto>>>> GetSiegeFromCommand(int commandId)
        {
            try
            {
                ServiceResponse<IEnumerable<SiegeDto>> response = await _businessSiege.GetSiegeFromCommand(commandId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("representation/available/{representationId}/{salleId}")]
        public async Task<ActionResult<IEnumerable<SiegeDto>>> GetSiegeFree(int representationId,int salleId)
        {
            try
            {
                ServiceResponse<IEnumerable<SiegeDto>> response = await _businessSiege.GetAvailbleByrepresentationId(representationId, salleId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{siegeId}")]
        public async Task<ActionResult<ServiceResponse<SiegeDto>>> GetSiegeById(int siegeId)
        {
            try
            {
                ServiceResponse<SiegeDto> response = await _businessSiege.GetSiegeById(siegeId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// rajouter un siege
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CreateSiege(AddSiegeDto addsiegedto)
        {
            try
            {
                var Validator = new AddSiegeValidator();
                var result = Validator.Validate(addsiegedto);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }
                ServiceResponse<SiegeDto> response = await _businessSiege.CreateSiegeForSalle(addsiegedto);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// modifier un siege
        /// </summary>
        /// <param name="siegeId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{siegeId}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> UpdateSiege(int siegeId ,[FromBody]UpdateSiegeDto updtSiegedto)
        {
            try
            {
                var Validator = new UpdateSiegeValidator();
                var result = Validator.Validate(updtSiegedto);
                if (!result.IsValid)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} Erreur de validation");
                }
                ServiceResponse<SiegeDto> response =await _businessSiege.UpdateSiegeById(siegeId, updtSiegedto);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }/// <summary>
        /// supprimer un siege
        /// </summary>
        /// <param name="siegeId"></param>
        /// <returns></returns>
        [HttpDelete("{siegeId}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> DeleteSiege(int siegeId)
        {
            try
            {
                ServiceResponse<SiegeDto> response= await _businessSiege.DeleteSiegeById(siegeId);
                if (!response.Success)
                {
                    return BadRequest($"{DateTime.Now:dd/mm/yy} error Message{response.Message}");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
