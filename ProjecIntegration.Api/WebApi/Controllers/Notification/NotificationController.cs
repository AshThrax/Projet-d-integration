using Application.Common.businessService;
using Application.DTO;
using ApplicationPublication.Dto;
using Domain.DataType;
using Domain.Entity.notificationEntity;
using Infrastructure.BusinessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Notification
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NotificationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddNotificationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("update-notification/{notifId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAnnonce(string notifId, [FromBody] UpdateNotificationDto annonce)
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
