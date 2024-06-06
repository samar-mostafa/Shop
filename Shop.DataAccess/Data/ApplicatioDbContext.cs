using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using Shop.Entities.Models;

namespace Shop.DataAccess
{
    public class ApplicatioDbContext:DbContext
    {
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options):base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
