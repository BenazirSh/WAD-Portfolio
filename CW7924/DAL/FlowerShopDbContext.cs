using CW7924.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW7924.DAL
{
    public class FlowerShopDbContext : DbContext
    {
        public FlowerShopDbContext(DbContextOptions<FlowerShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
    }
}
