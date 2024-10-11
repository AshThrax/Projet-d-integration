using ApplicationTheather.Services;
using ApplicationUser.Dto.FeedBack;
using ApplicationUser.Service;
using Domain.Entity.UserEntity.FeedBack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedBackController : GeneriqueController<Feedback, FeedBackDto, AddFeedBackDto, UpdateFeedbackDto>
    {
        private readonly IFeedBackService _feedBack;
        public FeedBackController(IFeedBackService feedBack) : base(feedBack)
        {
            _feedBack = feedBack;
        }
    }
}
