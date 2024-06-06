﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.IRepositories
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }
        int Complete();
    }
}
