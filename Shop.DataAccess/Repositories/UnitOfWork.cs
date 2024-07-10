using Shop.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _dbContext { get; set; }
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Category=new CategoryRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
           _dbContext.Dispose();
        }
    }
}
