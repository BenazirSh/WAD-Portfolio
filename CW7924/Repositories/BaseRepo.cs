using CW7924.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
   public abstract class BaseRepo
    {
        protected readonly FlowerShopDbContext _context;

        protected BaseRepo(FlowerShopDbContext context)
        {
            _context = context;
        }
    }
}
