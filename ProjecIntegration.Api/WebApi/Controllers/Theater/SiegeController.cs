using ApplicationTheather.BusinessService;
using ApplicationTheather.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("from-salle/{salleId}")]
        public async Task<ActionResult<IEnumerable<SiegeDto>>> GetSiegeFromSalle(int salleId)
        {
            try
            {
                return Ok(await _businessSiege.GetSiegeFromSalleId(salleId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("from-command/{commandId}")]
        public async Task<ActionResult<IEnumerable<SiegeDto>>> GetSiegeFromCommand(int commandId)
        {
            try
            {
                return Ok(await _businessSiege.GetSiegeFromCommand(commandId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{siegeId}")]
        public async Task<ActionResult<SiegeDto>> GetSiegeById(int siegeId)
        {
            try
            {
                return Ok(await _businessSiege.GetSiegeById(siegeId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("")]
        public async Task<ActionResult> CreateSiege(AddSiegeDto dto)
        {
            try
            {
                await _businessSiege.CreateSiegeForSalle(dto);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{siegeId}")]
        public async Task<ActionResult> UpdateSiege(int siegeId ,[FromBody]UpdateSiegeDto dto)
        {
            try
            {
                await _businessSiege.UpdateSiegeById(siegeId, dto);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{siegeId}")]
        public async Task<ActionResult> DeleteSiege(int siegeId)
        {
            try
            {
                await _businessSiege.DeleteSiegeById(siegeId);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
