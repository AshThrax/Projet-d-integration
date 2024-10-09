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
        Task<IEnumerable<Publication>> GetAllPublicationByPieceId(int pieceId);
        Task<IEnumerable<Publication>> GetAllPublicationByUserId(string userId);
        Task UpdatePublicationContent(string publicationid,string title, string content);
        Task<bool> Doexist(int pieceId, string userId);
    }
}
