using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelLayer.ViewModels;

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
            AddProductPhotos();// ONLY CALL IF PHOTOS NEED TO BE UPDATED
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

        public List<Cart> SearchCartList(Guid customerGuid)
        {
           
            List<Cart> cartList = new List<Cart>();
            foreach(Cart C in cartSet.Include(x => x.Owner).Include(x => x.Product))
            {
                if(C.Owner.CustomerId == customerGuid)
                {
                    cartList.Add(C);
                }

            }
            return cartList;
        }

        public void DeleteCart(Guid cartId)
        {
            Cart cart = cartSet.Where(x => x.CartId == cartId).Include(x => x.Product).Include(x => x.Owner).FirstOrDefault();
            Inventory invent = inventorySet.Where(x => x.Product.ProductName == cart.Product.ProductName).FirstOrDefault();
            if(invent == null)
            {
                invent = CreateInventory(cart);
            }
            if (cart != null)
            {
                cartSet.Remove(cart);
            //    inventorySet.Add(invent); cannot Update This in the database Entity Framework wont allow
               _dbcontext.SaveChanges();
            }
        }

        public Inventory CreateInventory(Cart cart)
        {
            Inventory invent = new Inventory();
            invent.Location = locationSet.Where(x => x.LocationId == cart.location).FirstOrDefault();
            invent.Product = cart.Product;
            invent.Quantity = cart.amount;
            return invent;
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
            return locationSet.ToList();
        }

        public List<Inventory> SearchInventoryList(int location)
        {
            //List<Location> blah = locationSet.ToList(); //pesky lazy loading will fix later
            //List<Product> blah2 = productSet.ToList();
            List<Inventory> inventoryList = new List<Inventory>();
            foreach(Inventory I in inventorySet.Include(x => x.Location).Include(x => x.Product))
            {
                
                if (I.Location.LocationId == location)
                {
                    inventoryList.Add(I);
                }
            }

            return inventoryList;
        }

        public void AddToCart(AmountToAddViewModel amountToAddView)
        {
            Cart currentCart = new Cart();
            currentCart.location = amountToAddView.location;
            currentCart.Owner = GetCustomerById(amountToAddView.CustomerId);
            currentCart.Product = GetProduct(amountToAddView.Product);
            currentCart.amount = amountToAddView.amount;
            cartSet.Add(currentCart);
            _dbcontext.SaveChanges();
        }

        public void SubtractFromInventory(int inventoryId, int amount)
        {
            foreach (Inventory inventory in inventorySet.Include(x => x.Location).Include(x => x.Product))
            {
                if (inventory.InventoryId == inventoryId)
                {

                    if (inventory.Quantity - amount == 0)
                    {
                        inventorySet.Remove(inventory);
                    }
                    else
                    {
                        Inventory temp = new Inventory();
                        temp.InventoryId = inventory.InventoryId;
                        temp.Location = inventory.Location;
                        temp.Product = inventory.Product;
                        temp.Quantity = inventory.Quantity - amount;
                        inventorySet.Remove(inventory);
                        inventorySet.Add(temp);
                    }
                }

            }
            _dbcontext.SaveChanges();
        }

        public List<Order> SearchOrderList(int locationId)
        {
            List<Order> orderList = new List<Order>();
            foreach (Order O in orderSet.Include(x => x.Customer).Include(x => x.Location))
            {
                if (O.Location.LocationId == locationId)
                {
                    orderList.Add(O);
                }

            }
            return orderList;

        }

        public Cart GetCart(Guid cart)
        {
            Cart cartObject = new Cart();
            cartObject = cartSet.Where(x => x.CartId == cart).Include(x => x.Owner).Include(x => x.Product).FirstOrDefault();
            return cartObject;
        }

        public Location GetLocationById(int locationId)
        {
            Location location = new Location();
            location = locationSet.Where(x => x.LocationId == locationId).FirstOrDefault();
            return location;
        }

        public void OrderNow(Guid cartId)
        {
            Order newOrder = new Order();
            Cart cart = new Cart();
            cart = GetCart(cartId);

            newOrder.Amount = cart.amount;
            newOrder.Customer = cart.Owner;
            newOrder.Location = GetLocationById(cart.location);
            newOrder.Price = cart.Product.Price * cart.amount;
            newOrder.ProductName = cart.Product.ProductName;
            newOrder.Date = DateTime.Now;

            orderSet.Add(newOrder);
            _dbcontext.SaveChanges();
        }

       /* public Order ViewOrderHistory(int LocationId, Guid CustomerId)
        {
            Order order = new Order();
            order = orderSet.Where(x => x.Location.LocationId == LocationId).Include(x => x.Location).Include(x => x.Customer).FirstOrDefault();
            return order;
        }
*/
        /// <summary>
        /// Only called when Product pictures need to be updated
        /// Must REMAKE THE METHOD CALL IN A LOGIN METHOD AS IT SHOULD NOT BE THERE
        /// IN THE ACTUAL USER SESSION
        /// </summary>
        /// <returns></returns>
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
