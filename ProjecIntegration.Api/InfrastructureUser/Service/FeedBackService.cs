using ApplicationTheather.Services;
using ApplicationUser.Dto.FeedBack;
using ApplicationUser.Repository;
using AutoMapper;
using Domain.Entity.UserEntity.FeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Service
{
    public class FeedBackService : Service<Feedback, FeedBackDto,AddFeedBackDto,UpdateFeedbackDto>, IFeedBackService
    {
        IFeedBackRepository _repository;
        public FeedBackService(IFeedBackRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
