using Shop.Entities.IRepositories;
using Shop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories
{
    internal class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly ApplicatioDbContext _dbContext;
        public ProductRepository(ApplicatioDbContext dbContext):base(dbContext)
        {

            _dbContext = dbContext;

        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
