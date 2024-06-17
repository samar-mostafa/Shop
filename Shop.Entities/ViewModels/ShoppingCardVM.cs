using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.ViewModels
{
    public class ShoppingCardVM
    {
        public ProductViewVM Product { get; set; }
        public int Quantity { get; set; }
    }
}
