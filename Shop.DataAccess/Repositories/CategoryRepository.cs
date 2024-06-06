using Shop.Entities.Models;
using Shop.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public ApplicatioDbContext _dbContext { get; set; }
        public CategoryRepository(ApplicatioDbContext dbContext):base(dbContext) 
        {

            _dbContext = dbContext;

        }

        public void Update(Category category)
        {
            var entity = _dbContext.Categories.SingleOrDefault(c=>c.Id== category.Id);
            if(entity != null)
            {
                entity.Name=category.Name;
                entity.Description=category.Description;

            }
        }
    }
}
