using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RepositoryLayer
{
    public class Repository
    {

        private readonly ProjectDbContext _dbcontext;
        private readonly ILogger<Repository> _logger;
        DbSet<Customer> customerSet;
        DbSet<Product> productSet;
        DbSet<Order> orderSet;
        DbSet<Location> locationSet;
        DbSet<Cart> cartSet;
        DbSet<Inventory> inventorySet;

        public Repository(ProjectDbContext dbcontext, ILogger<Repository> logger)
        {
            _dbcontext = dbcontext;
            this.customerSet = _dbcontext.Customers;
            this.productSet = _dbcontext.Products;
            this.orderSet = _dbcontext.Orders;
            this.locationSet = _dbcontext.Locations;
            this.cartSet = _dbcontext.Carts;
            this.inventorySet = _dbcontext.Inventories;
            _logger = logger;
        }

        public Customer LogInCustomerWithUserName(string userName)
        {
            Customer user = customerSet.Where(x => x.Uname == userName).FirstOrDefault();
            if(user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }


        public Customer LogInCustomer(Customer customer)
        {
            Customer customer1 = customerSet.FirstOrDefault(x => x.Uname == customer.Uname);

            if (customer1 == null)
            {
                customer1 = new Customer()
                {
                    Fname = customer.Fname,
                    Lname = customer.Lname,
                    Uname = customer.Uname
                };
                customerSet.Add(customer1);
                _dbcontext.SaveChanges();
                try
                {
                    Customer C2 = customerSet.FirstOrDefault(x => x.CustomerId == customer1.CustomerId);// check if the player is in the Db
                    return C2;
                }
                catch (ArgumentNullException ex)
                {
                    _logger.LogInformation($"Saving a player to the Db threw an error, {ex}");
                }
            }
            //return customer1;
            return null;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            Customer customer = customerSet.FirstOrDefault(x => x.CustomerId == customerId);
            return customer;
        }

        public Customer EditCustomer(Customer customer)
        {

            Customer customer1 = GetCustomerById(customer.CustomerId);
            customer1.Fname = customer.Fname;
            customer1.Lname = customer.Lname;
            customer1.Uname = customer.Uname;
            customer1.ByteArrayImage = customer.ByteArrayImage;
            _dbcontext.SaveChanges();

            Customer anotherCustomer = GetCustomerById(customer.CustomerId);

            return anotherCustomer;

        }

        public List<Location> LocationList()
        {
           // AddProductPhotos(); Only called to update pictures if need be
            return locationSet.ToList();
        }

        public List<Inventory> SearchInventoryList(int location)
        {

            List<Location> blah = locationSet.ToList(); //pesky lazy loading
            List<Product> blah2 = productSet.ToList();
            List<Inventory> inventoryList = new List<Inventory>();
            foreach(Inventory I in inventorySet)
            {
                if (I.Location.LocationId == location)
                {
                    inventoryList.Add(I);
                }
            }

            return inventoryList;
        }

        public Cart GetCart(Guid customerGuid)
        {
            return cartSet.Where(x => x.Owner.CustomerId == customerGuid).FirstOrDefault();
        }

        public Product GetProduct(string pName)
        {
            Product tempProduct = productSet.Where(x => x.ProductName == pName).FirstOrDefault();
            return tempProduct;
        }

        public int GetInventoryStock(int inventoryId)
        {
            Inventory invent = new Inventory();
            invent = inventorySet.Where(x => x.InventoryId == inventoryId).FirstOrDefault();
            int stock = invent.Quantity;
            return stock;
        }
        public void AddProductPhotos()
        {
            int count = 1;
            foreach(Product P in productSet)
            {
                if(count == 1)
                {
                    P.ByteArrayImage = System.IO.File.ReadAllBytes(@"wwwroot\Project1Images\REDAPPLE.jpg");
                }
                if (count == 2)
                {
                    P.ByteArrayImage = System.IO.File.ReadAllBytes(@"wwwroot\Project1Images\Bacon.jpg");
                }
                if (count == 3)
                {
                    P.ByteArrayImage = System.IO.File.ReadAllBytes(@"wwwroot\Project1Images\Beans.jpeg");
                }
                if (count == 4)
                {
                    P.ByteArrayImage = System.IO.File.ReadAllBytes(@"wwwroot\Project1Images\WaterBottle.jpg");
                }
                if (count == 5)
                {
                    P.ByteArrayImage = System.IO.File.ReadAllBytes(@"wwwroot\Project1Images\orange.jpg");
                }
                if (count == 6)
                {
                    P.ByteArrayImage = System.IO.File.ReadAllBytes(@"wwwroot\Project1Images\pear.jpg");
                }
                count++;
            }
            _dbcontext.SaveChanges();


        }


    }
}
