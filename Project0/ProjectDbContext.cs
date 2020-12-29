
using Microsoft.EntityFrameworkCore;
using System;

namespace Project0
{
    public class ProjectDbContext :  DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations {get; set; }
        public DbSet<Inventory> Inventories {get; set;}
        public DbSet<Cart> Carts {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project0;Trusted_Connection=True;");
        }
    }
}