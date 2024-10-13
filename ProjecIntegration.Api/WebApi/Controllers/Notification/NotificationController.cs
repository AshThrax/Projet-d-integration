using ApplicationAnnonce.Common.businessService;
using ApplicationAnnonce.DTO;
using Domain.DataType;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationBl _notificationBl;
        private readonly ICustomGetToken _customGetToken;

        public NotificationController(ILogger<NotificationController> logger,ICustomGetToken customGetToken ,INotificationBl notificationBl)
        {
            _logger = logger;
            _customGetToken = customGetToken;
            _notificationBl = notificationBl;
        }
        [HttpGet("get-notification")]
        
        public async Task<ActionResult> GetAll([FromQuery] int pageNumber)
        {
            try
            {
                Pagination<NotificationDto> paged = await _notificationBl.GetNotificationByUserId(await _customGetToken.GetSub(),pageNumber);
                return Ok(paged);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get-notification/{notificationId}")]
        public async Task<ActionResult> GetById(string notificationId)
        {
            try
            {
                return Ok(await _notificationBl.GetNotificationById(notificationId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("post-notification")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddNotificationDto))]
        public async Task<ActionResult> CreateAnnonce([FromBody] AddNotificationDto notificationDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                _notificationBl.CreateNotification(notificationDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-notification/{notifId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAnnonce(int notifId, [FromBody] UpdateNotificationDto annonce)
        {
            try
            {
                if (annonce != null)
                {
                    await _notificationBl.UpdateNotification(notifId, annonce);
                    return NoContent();
                }

                return BadRequest("contenue null");

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("supress-notification/{notificationId}")]
      
        public async Task<ActionResult> UpdateAnnonce(string notificationId)
        {
            try
            {
                await _notificationBl.DeleteNotification(notificationId);
                return NoContent();
            }
            catch (ArgumentNullException ex)
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
