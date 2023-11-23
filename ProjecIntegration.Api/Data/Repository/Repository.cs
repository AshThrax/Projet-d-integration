using Data.Persistence;
using Domain.IRepository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<T> :IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            dbSet =dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() 
        { 
            return dbSet.AsEnumerable();
        }
        public T GetById(int id) 
        {
            return dbSet.SingleOrDefault(s=> s.Id == id);
        }
        public  void Insert (T entity) {
            if (entity == null) { }
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }
        public void Update (T entity) 
        {
            if (entity == null) { }
        }
        public void Delete (T entity) 
        {
            if(entity ==null) 
            {
                
            }
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
