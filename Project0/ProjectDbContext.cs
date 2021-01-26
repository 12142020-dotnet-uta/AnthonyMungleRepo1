
using Microsoft.EntityFrameworkCore;
using System;

namespace Project0
{
    public class ProjectDbContext :  DbContext
    {                                          //All DBsets are used to retrive and access data from the database
        public DbSet<Customer> Customers { get; set; } //Database Set for Customers
        public DbSet<Product> Products { get; set; } //Database Set for Products
        public DbSet<Location> Locations {get; set; }//Database Set forLocation
        public DbSet<Inventory> Inventories {get; set;} //Database Set for Inventory
        public DbSet<Cart> Carts {get; set;} // Database Set for Carts
        public DbSet<Order> Orders {get; set;} // Database Set for Orders

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project0;Trusted_Connection=True;");
        }
    }
}