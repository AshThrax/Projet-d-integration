using Application.Common.Repository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity;
using System.Linq.Expressions;

namespace dataInfraTheather.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            dbSet = dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await dbSet.ToListAsync();
            return entities;
        }
        public Task<T> GetById(int id)
        {
            return dbSet.FirstOrDefaultAsync(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) { }
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }
        public void Update(int updtId, T entity)
        {
            if (entity == null)
            {

            }
            dbSet.Update(entity);
            dbContext.SaveChanges();
        }
        public void Delete(int entityid)
        {
            var ent = dbSet.SingleOrDefaultAsync(x => x.Id == entityid).Result;
            if (ent == null)
            {
                //lance une exception qui avertit que l'entité 
                //qu'on desire supprimer n'existe pas
                throw new ArgumentNullException(nameof(entityid), "L'entité que vous souhaitez supprimer n'existe pas.");

            }
            dbSet.Remove(ent);
            dbContext.SaveChanges();
        }
    }
}
