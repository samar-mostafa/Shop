﻿using Shop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.IRepositories
{
    public interface IProductRepository:IRepository<Product>
    {
        void Update(Product product);
    }
}
