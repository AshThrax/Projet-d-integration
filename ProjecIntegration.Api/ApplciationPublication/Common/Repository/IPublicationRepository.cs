using Domain.Entity.notificationEntity;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Common.Repository
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Annonce>> GetAll(params Expression<Func<Publication, object>>[] includeProperties);
        Task<Annonce> GetById(string id, params Expression<Func<Publication, object>>[] includeProperties);
        Task<IEnumerable<Publication>> GetAll();
        Task<Publication> GetById(string id);
        void Insert(Publication entity);
        void Update(string entityId, Publication entity);
        void Delete(string entityId);
        Task UpdatePublicationContent(string publicationid, string content);
    }
}
