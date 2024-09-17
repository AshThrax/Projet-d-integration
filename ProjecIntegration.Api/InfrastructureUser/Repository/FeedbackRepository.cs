using ApplicationUser.Repository;
using Domain.Entity.UserEntity.FeedBack;
using InfrastructureUser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedBackRepository
    {
        public FeedbackRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
