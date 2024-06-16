using Microsoft.EntityFrameworkCore;
using Shop.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicatioDbContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(ApplicatioDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet=_dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

       

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeWord = null)
        {
            IQueryable<T> query = _dbSet;
            if(predicate != null)
                query = query.Where(predicate);
            if(includeWord != null)
            {
                foreach(var word in includeWord.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(word);
                }
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? predicate = null, string? includeWord = null)
        {
            var query = GetAll(predicate, includeWord);
                return query.FirstOrDefault();    
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
