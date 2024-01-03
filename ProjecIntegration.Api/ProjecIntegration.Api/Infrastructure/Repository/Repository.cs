using ProjecIntegration.Api.Models.BaseEntity;
using Microsoft.EntityFrameworkCore;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;

namespace ProjecIntegration.Api.infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await dbSet.ToListAsync();
            return entities;
        }
        public Task<T> GetById(int id)
        {
            return dbSet.SingleOrDefaultAsync(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) { }
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) { }
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {

            }
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
