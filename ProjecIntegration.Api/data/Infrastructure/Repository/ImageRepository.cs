using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using dataInfraTheather.Infrastructure.Repository;
using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfraTheather.Infrastructure.Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
