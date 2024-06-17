using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.ViewModels
{
    public class ProductViewVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
    
    }
}
