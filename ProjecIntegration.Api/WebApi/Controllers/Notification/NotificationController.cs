using Application.Common.businessService;
using Application.DTO;
using Domain.Entity.notificationEntity;
using Infrastructure.BusinessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Notification
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _notificationBl.GetNotificationByUserId(await _customGetToken.GetSub()));
            }
            catch (Exception ex)
            {
                return NotFound();
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
                return NotFound();
            }
        }

        [HttpPost("post-notification")]
        public async Task<ActionResult> CreateAnnonce([FromBody] AddNotificationDto notificationDto)
        {
            try
            {
                await _notificationBl.CreateNotification(notificationDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("update-notification/{notifId}")]
        public async Task<ActionResult> UpdateAnnonce(string notifId, [FromBody] UpdateNotificationDto annonce)
        {
            try
            {
                if (annonce != null)
                {
                    await _notificationBl.UpdateNotification(notifId, annonce);
                    return NoContent();
                }

                return BadRequest();

            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
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
            catch (ArgumentNullException exception)
            {
                return NotFound();
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
    }
}
