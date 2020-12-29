using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project0
{
    /// <summary>
    /// Class Handler handles any methods that need to retrive or update to the connected database 
    /// </summary>
    public class Handler
    {

        static ProjectDbContext DbContext = new ProjectDbContext();
        DbSet<Customer> customersSet = DbContext.Customers;
        DbSet<Product> productsSet = DbContext.Products;
        DbSet<Location> LocationsSet = DbContext.Locations;
        DbSet<Inventory> InventoriesSet = DbContext.Inventories;
        DbSet<Cart> CartSet = DbContext.Carts;

        // public Handler(ProjectDbContext context)
        // {
        //     Handler.DbContext = context;
        // }
        
        
       public Customer createCustomer()
       {
           string fname = "";
           string lname = "";
           string uname = "";
            do
            {
                Console.WriteLine("Please Type you First name");
                fname = Console.ReadLine();
                Console.WriteLine("Please Type you Last name");
                lname = Console.ReadLine();
                Console.WriteLine("Please Type your userName");
                uname = Console.ReadLine();
                if(fname == "" || lname == "" || uname == "" )
                {
                    Console.WriteLine("You must type a name");
                }
            }while(fname == "" || lname == "" || uname == "");
           
           
           Customer customer = new Customer();
           customer = customersSet.Where(x => x.Uname == uname).FirstOrDefault();

            if(customer == null)
            {
                customer = new Customer()
                {
                    Fname = fname,
                    Lname = lname,
                    Uname = uname
                };
                customersSet.Add(customer);
                DbContext.SaveChanges();
                return customer;
            }
            else
            {
            Console.WriteLine("This UserName already Exists.\nTry Another");

            do{
                Console.WriteLine("Please Type a unique userName");
                uname = Console.ReadLine();
                customer = customersSet.Where(x => x.Uname == uname).FirstOrDefault();

                if(customer == null && uname != "")
                {
                    customer = new Customer()
                    {
                        Fname = fname,
                        Lname = lname,
                        Uname = uname
                    };
                    customersSet.Add(customer);
                    DbContext.SaveChanges();
                    return customer;
                }
                uname = "";
             }while(uname == "");
            }
         return null;
       }

/// <summary>
/// Logs In to an already created Customer from the Database returns null if User Does Not Exist
/// </summary>
/// <returns>Customer</returns>
      public Customer logIn()
      {
          string uname;
          do{
            Console.WriteLine("Please Type your userName");
            uname = Console.ReadLine();
          }while(uname == "");

          Customer customer = new Customer();
          customer = customersSet.Where(x => x.Uname == uname).FirstOrDefault();

           if(customer == null)
            {
                Console.WriteLine("This username does not exist!");
                return null;
            }
            else
            {
                return customer;
            }

      }

/// <summary>
/// Prints The Locations listed in the database using the DBsets returns the Location's ID in a List<>
/// </summary>
/// <returns>List(int)</returns>
      public List<int> PrintLocations()
      {
          int i = 1;
          List<int> LocationIdList = new List<int>();
          List<Location> LocationList = new List<Location>();
          LocationList = LocationsSet.ToList();
          foreach(Location L in LocationList)
          {
            Console.WriteLine($"{i++}: {L.LocationName}");
            LocationIdList.Add(L.LocationId);
          }

          Console.WriteLine($"\n{i++}: --Exit--");
        return LocationIdList;

      }


    /// <summary>
    /// Takes in a userChoice INT and a LIST(INT) compares them to each and then selects that matching LocationID from
    /// the database prints out the name of that location
    /// </summary>
    /// <param name="userChosenSpace"></param>
    /// <param name="LocationIdList"></param>
    /// <returns></returns>
      public string GetLocationName(int userChosenSpace, List<int> LocationIdList)
      {
        int locationID = LocationIdList[userChosenSpace-1];
        Location local = new Location();
        local = LocationsSet.Where(x => x.LocationId == locationID).FirstOrDefault();
        if(local == null)
        {
            Console.WriteLine("There Was An Error Handling Your Request");
            return "error";
        }
        return local.LocationName;

      }

    /// <summary>
    /// Takes in a userChoice INT and a LIST(INT) compares them to each and then selects that matching ID from 
    /// the connected database. Compares the FKey to a list of Products available then prints out the names and prices 
    /// of the matching products
    /// </summary>
    /// <param name="userChosenSpace"></param>
    /// <param name="LocationIdList"></param>
      public void ShowInventory(int userChosenSpace , List<int> LocationIdList, Customer user)
      {
        int counter = 1;
        int locationID = LocationIdList[userChosenSpace-1];
        Location local = new Location();
        local = LocationsSet.Where(x => x.LocationId == locationID).FirstOrDefault();
        Console.WriteLine($"{local.LocationName}");
        List<Inventory> LocationInventory = new List<Inventory>();
        LocationInventory = UpdateInventoryList(local);
        List<Product> FullProductList = productsSet.ToList();    //it likes to have this or else it will not work  
        //  foreach(Inventory I in InventoriesSet)
        //  {
        //      if(I.Location == local)
        //      {
        //          LocationInventory.Add(I);
        //          //Console.WriteLine($"{LocationInventory[i].Product.ProductName}");
                
        //      } 
        // }
          
        for(int i = 0; i < LocationInventory.Count; i++ )
          {
            Console.WriteLine($"Item {counter}: {LocationInventory[i].Product.ProductName} ${LocationInventory[i].Product.Price}\n\t{LocationInventory[i].Product.Description} {LocationInventory[i].Quantity} Left.");
            counter ++;
          }
          Console.WriteLine($"\n{counter}: --Place Order--");
          Console.WriteLine($"{counter+1}: ----Exit---- \n\tYour cart will stay if you dont log out\n");

        ChooseInventory(LocationInventory, user, local);
      
      }

/// <summary>
/// 
/// </summary>
/// <param name="location"></param>
/// <returns></returns>
      public List<Inventory> UpdateInventoryList(/*List<Inventory> LocationInventory*/ Location location)
      {

        List<Inventory> LocationInventory = new List<Inventory>();
        foreach(Inventory I in InventoriesSet)
        {
            if(I.Location == location)
            {
                LocationInventory.Add(I);
            } 
        }
        return LocationInventory;
      }


/// <summary>
/// 
/// </summary>
/// <param name="InventoryList"></param>
/// <param name="user"></param>
/// <param name="local"></param>
      public void ChooseInventory( List<Inventory> InventoryList, Customer user, Location local)
      {
        int count = 1;
        int userInput = 0;
        int userQuantity = 0;
        int Exit = 0;
        int PlaceOrder = 0;
        Product currentProduct = new Product();

        do
        {   
              
          if(!InventoryList.Any())
          {Console.WriteLine("ALERT--------Sorry this store is out of Inventory----"); break;}  

          do
          {
            userInput = WasUserChoiceInt(Console.ReadLine());
            if(userInput == -1)
            {
              Console.WriteLine("Please choose by number.");
            }
          }while(userInput == -1);

          if(userInput < PlaceOrder && userInput > 0) //Makes user input a correct value
          {
            currentProduct = productsSet.Where(x => x.ProductName == InventoryList[userInput-1].Product.ProductName).FirstOrDefault();
            Console.WriteLine($"\n{currentProduct.ProductName} ${currentProduct.Price}");
            Console.WriteLine("Please choose Quantity to add to cart.");
          
            do
            {
              userQuantity = WasUserChoiceInt(Console.ReadLine());
              if(userQuantity == -1 || userQuantity > InventoryList[userInput-1].Quantity || userQuantity < 0  )
              {
                Console.WriteLine("Please choose a number Or Make sure you have not exceeded the amount available! Zero to add Nothing");
              }
            }while(userQuantity == -1 || userQuantity > InventoryList[userInput-1].Quantity || userQuantity < 1 );
          
            //RemoveFromInventory(InventoryList[userInput-1].InventoryId, userQuantity);
            //InventoryList = UpdateInventoryList(local);//Should Update List everytime to show remaining availability
            //AddToCart(user, currentProduct, userQuantity );
          }

          for(int i = 0; i < InventoryList.Count; i++ )
          {
            Console.WriteLine($"Item {count}: {InventoryList[i].Product.ProductName} ${InventoryList[i].Product.Price}\n\t{InventoryList[i].Product.Description} {InventoryList[i].Quantity} Left.");
            count ++;
          }

          Exit = InventoryList.Count + 2;
          PlaceOrder = InventoryList.Count + 1; 
          Console.WriteLine($"\n{PlaceOrder}: --Place Order--");
          Console.WriteLine($"{Exit}: ----Exit---- \n\tYour cart will stay if you dont log out");
          count = 1;
          
          if(userInput == PlaceOrder)
          {
            Console.WriteLine("Placing Order...\n");
            PlaceCartInOrder(user);
          }
          if(userInput == Exit)
          {
            Console.WriteLine("Exiting...\n");
          }

      }while(userInput != Exit && userInput != PlaceOrder);
      
    }
    

      /// <summary>
      /// 
      /// </summary>
      /// <param name="customerId"></param>
      /// <param name="addThisProduct"></param>
      /// <param name="amount"></param>
      public void AddToCart (Customer customerId, Product addThisProduct, int amount)
      {

        Cart currentCart = new Cart();
        currentCart.Owner = customerId;
        currentCart.Product = addThisProduct;
        currentCart.amount = amount;
        CartSet.Add(currentCart);
        DbContext.SaveChanges();
        
        Console.WriteLine("Item Added To Cart");
      }

      public void PlaceCartInOrder(Customer user)
      {
        Cart cartToBeDestroyed = new Cart();
        cartToBeDestroyed = CartSet.Where(x => x.Owner == user).FirstOrDefault();
        


      }

      /// <summary>
      /// Removes the selected quantity from an inventory item using the PK from the database 
      /// </summary>
      /// <param name="inventoryId"></param>
      /// <param name="productRemoved"></param>
      /// <param name="quantity"></param>
      public void RemoveFromInventory(int inventoryId, int quantity)
      {
         foreach(Inventory inventory in InventoriesSet)
         {
           if(inventory.InventoryId == inventoryId)
           { 
             
             if(inventory.Quantity - quantity == 0)
             {
               InventoriesSet.Remove(inventory);
             }
             else
             {
               Inventory temp = new Inventory();
               temp.InventoryId = inventory.InventoryId;
               temp.Location = inventory.Location;
               temp.Product = inventory.Product;
               temp.Quantity = inventory.Quantity - quantity;
               InventoriesSet.Remove(inventory);
               InventoriesSet.Add(temp);
             }
            

           }
         }
        DbContext.SaveChanges();
      }

      /// <summary>
        /// Makes sure the user inputs an int otherwise returns a negative 1
        /// </summary>
        /// <param name="userChoice"></param>
        /// <returns></returns>
        public  static int WasUserChoiceInt(string userChoice)
        {

            int result;
            bool realChoice = int.TryParse(userChoice, out result);
            if(realChoice == false)
            {
                Console.WriteLine("Invalid response");
                return -1; 
            }
            Console.WriteLine(result);
            return result;

        }

/// <summary>
/// A test to make sure the database was connected and that i knew what i was doing.
/// Shall not be used in the actual project.
/// </summary>
      public void PrintStuff()
      {
          string uname = "Apples";
            Product P = new Product();
           P = productsSet.Where(x => x.ProductName == uname).FirstOrDefault();
              Console.WriteLine($"{P.ProductName}");

            uname = "Publix";
            Location L = new Location();
            L = LocationsSet.Where(x => x.LocationName == uname).First();
            Console.WriteLine($"{L.LocationName}");
      }


    }//EndClass
}