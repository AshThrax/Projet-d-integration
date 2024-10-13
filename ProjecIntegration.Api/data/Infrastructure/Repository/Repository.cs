using ApplicationTheater.Common;
using ApplicationTheather.Common.IRepository;
using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity;
using System.Linq.Expressions;

namespace dataInfraTheather.Infrastructure.Repository
{
    public class Repository<T> :  IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            try
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return await query.ToListAsync();

            }
            catch (Exception)
            {

                return Enumerable.Empty<T>();
            }
        }
        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            try
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return await query.SingleOrDefaultAsync(s => s.Id == id) ?? throw new NullReferenceException();

            }
            catch (Exception)
            {

                return query.First();
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var entities = await _dbSet.ToListAsync();
                return entities;

            }
            catch (Exception)
            {

                return Enumerable.Empty<T>();
            }
        }
        public async Task<T> GetById(int id)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(s => s.Id == id) ?? throw new NullReferenceException();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> Insert(T entity)
        {
            T data = _dbSet.Add(entity).Entity;
            await _dbContext.SaveChangesAsync();
            return data;
        }
        public async Task Update(int updtId, T entity)
        {
            if (entity != null)
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();

            }
        }
        public async Task Delete(int entityid)
        {
            var ent = _dbSet.SingleOrDefaultAsync(x => x.Id == entityid).Result;
            if (ent == null)
            {
                //lance une exception qui avertit que l'entité 
                //qu'on desire supprimer n'existe pas
                throw new ArgumentNullException(nameof(entityid), "L'entité que vous souhaitez supprimer n'existe pas.");

            }
            _dbSet.Remove(ent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetByListIds(List<int> ListIds)
        {
            IEnumerable<T> values = await _dbSet.Where(x => ListIds.Contains(x.Id)).ToListAsync();

            return values;
        }

        public async Task<bool> DoYouExist(int id)
        {
            try
            {
                int count = await _dbSet.Where(x => x.Id == id).CountAsync();

                return count > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> includeProperties)
        {
            IQueryable<T> query = _dbSet;
            try
            {

                if (includeProperties != null)
                {
                    query = query.Where(includeProperties);
                }

                return await query.SingleOrDefaultAsync() ?? throw new NullReferenceException();

            }
            catch (Exception)
            {

                return query.First();
            }
        }
        public async Task<T> Get(Expression<Func<T, bool>> findProperties, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            try
            {

                if (includeProperties != null)
                {
                    query = query.Where(findProperties);
                }
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return await query.SingleOrDefaultAsync() ?? throw new NullReferenceException();

            }
            catch (Exception)
            {

                return query.First();
            }
        }
        public async Task<bool> DoYouExist(Expression<Func<T, bool>> includeProperties)
        {
            IQueryable<T> query = _dbSet;
            try
            {

                if (includeProperties != null)
                {
                    query = query.Where(includeProperties);
                }
                int count = await query.CountAsync();
                return count > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllCustomWithInclude(Expression<Func<T, bool>> findProperties, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            try
            {

                if (includeProperties != null)
                {
                    query = query.Where(findProperties);
                }
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return await query.ToListAsync() ?? throw new NullReferenceException();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
