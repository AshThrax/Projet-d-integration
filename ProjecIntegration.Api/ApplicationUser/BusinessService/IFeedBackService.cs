using ApplicationUser.Dto.FeedBack;
using ApplicationUser.Service;
using Domain.Entity.UserEntity.FeedBack;


namespace ApplicationTheather.Services
{
    public interface IFeedBackService : IService<Feedback, FeedBackDto, AddFeedBackDto, UpdateFeedbackDto>
    {
    }
}
