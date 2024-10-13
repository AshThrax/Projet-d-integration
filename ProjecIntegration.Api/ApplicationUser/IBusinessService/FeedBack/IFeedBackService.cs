using ApplicationUser.Dto.FeedBack;
using ApplicationUser.Service;
using Domain.Entity.UserEntity.FeedBack;


namespace ApplicationUser.BusinessService.FeedBack
{
    public interface IFeedBackService : IService<Feedback, FeedBackDto, AddFeedBackDto, UpdateFeedbackDto>
    {
    }
}
