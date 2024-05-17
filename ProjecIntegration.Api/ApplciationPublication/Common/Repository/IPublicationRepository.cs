using Domain.Entity.notificationEntity;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.Repository
{
    public interface IPublicationRepository:IRepository<Publication>
    {
        Task<IEnumerable<Publication>> GetAllbyPublicationByUserId(string userId);
       
        Task UpdatePublicationContent(string publicationid,string title, string content);
        
      
    }
}
