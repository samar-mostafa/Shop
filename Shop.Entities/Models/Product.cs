using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Discription { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
