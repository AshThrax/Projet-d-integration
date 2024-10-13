using ApplicationUser.BusinessService.FeedBack;
using ApplicationUser.Common.Repository;
using ApplicationUser.Dto.FeedBack;
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
        private readonly IFeedBackRepository _repository;
        public FeedBackService(IFeedBackRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
