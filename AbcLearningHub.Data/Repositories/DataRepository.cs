using System;
using System.Collections.Generic;
using System.Text; 
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AbcLearningHub.Data.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        Task Delete(object id);
        Task Delete(T entity);
        Task<T> Find(int id);
        Task<T> Find(long id);
        Task<T> Find(string id);
        Task Insert(T item);
        IQueryable Query();
        IQueryable Query(Expression<Func<T, bool>> predicate);
        IQueryable Query(Expression<Func<T, bool>> predicate, string include);
        IQueryable Query(string include);
        Task Update(T item);
    }
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private DbContext _dbContext;
        protected readonly DbSet<T> DbSet;
        public DataRepository(DbContext context)
        {
            _dbContext = context;
            DbSet = _dbContext.Set<T>();
        }

        public async Task Delete(object id) 
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                await Delete(entity);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;            
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Find(int id) 
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> Find(long id) 
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> Find(string id) 
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Insert(T item) 
        {
            _dbContext.Entry(item).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
        }

        public  IQueryable Query() 
        {
            return DbSet;
        }

        public IQueryable Query(Expression<Func<T, bool>> predicate) 
        {
            return DbSet.Where(predicate);
        }

        public IQueryable Query(string include)
        {
            
            return DbSet.Include(include);
        }
        public IQueryable Query(Expression<Func<T, bool>> predicate, string include)
        {
            
            return DbSet.Where(predicate).Include(include);
        }

        public async Task Update(T item) 
        {
            if (_dbContext.Entry(item).State == EntityState.Detached)
            {
                DbSet.Attach(item);
            }
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
