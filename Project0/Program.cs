using System;
using System.Collections.Generic;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            int userOption = 0; //Used to navigate the menu
            Handler Handler = new Handler(); // used to Handle and check user input
            Customer currentUser = new Customer();//The current customer to be logged on
            currentUser = null;

            while(userOption != 4)
            {
                userOption = MainMenu();
                if(userOption == 4)
                {
                    currentUser = null;
                    break;  
                }

                if(userOption == 1)//Option to create user
                {
                    currentUser = Handler.logIn();
                   if(currentUser == null)
                    {
                        Console.WriteLine("Returning to main menu");
                    }
                }

                if(userOption == 2) //Option to Create Customer
                {
                    currentUser = Handler.createCustomer();
                    if(currentUser == null)
                    {
                        Console.WriteLine("Returning to main menu");
                    }  
                }

                if(userOption == 3 && currentUser != null) //Insures the user has Logged in and there is a Customer Value
                { 
                    userOption = LocaionOrOrderViewMenu(currentUser);

                    if(userOption == 1) //Location Choosing service and Shopping
                    {
                        int userLocationOption; //User Will choose from a list of available locatoins
                        int exitOption; //Will be one more then nmberOfLocations
                        int numberOfLocations;// Wil get value from handler.printLocations().count
                        List<int> LocationIdList = new List<int>();
                        
                        do
                        {
                            Console.WriteLine("\nSelect From The List Provided");
                            LocationIdList = Handler.PrintLocations();
                            numberOfLocations = LocationIdList.Count;

                            exitOption = numberOfLocations + 1;
                           // Console.WriteLine($"{numberOfLocations}");
                            userLocationOption = WasUserChoiceInt(Console.ReadLine());
                            
                            if(userLocationOption == exitOption){break;}
                    
                            if(userLocationOption > numberOfLocations || userLocationOption < 1)
                            {
                                Console.WriteLine("Please use a VALID option by choosing a Location from the provided list.\n");
                            }
                            
                        } while(userLocationOption > numberOfLocations || userLocationOption < 1);
                        if(userLocationOption != exitOption)
                        {
                            Console.WriteLine($"\nYou Have Chosen {Handler.GetLocationName(userLocationOption, LocationIdList)} shops");
                            Console.WriteLine("Which Items Would you like to put in your cart?\n");

                            Handler.ShowInventory(userLocationOption, LocationIdList, currentUser);

                        }
                    }

                    if(userOption == 2)//Order service
                    {
                        int userOrderMenuChoice = 0;
                        do
                        {
                            userOrderMenuChoice = OrderService();

                            if(userOrderMenuChoice == 1)
                            {
                                Handler.PrintCurrentUserOrderHistory(currentUser);
                            }

                            if(userOrderMenuChoice == 2)
                            {
                                Handler.PrintCurrentUsersCart(currentUser);
                            }

                            if(userOrderMenuChoice == 3)
                            {
                                Console.WriteLine("Please type a username to locate a Customer");
                                Handler.PrintCustomerByUsername(Console.ReadLine());
                            }

                            if(userOrderMenuChoice == 4)
                            {
                                Console.WriteLine("Please type the name of the location");
                                Handler.PrintLocationOrderHistory(Console.ReadLine());
                            }

                        }while(userOrderMenuChoice != 5);
                        //press number to exit
                    }
                    if(userOption == 3){ userOption = 0; break;}

                }//End of If(User != null)

                else if(userOption == 3 && currentUser == null)
                {
                    Console.WriteLine("\nYou must be logged in to continue");
                }

            } //End of while(userOption != 3) Main menu loop
        }//End of Main()

//----------------Non Main Methods start HERE---------------

/// <summary>
/// TAkes the users input; insures it is correct uses the WasUserChoiceInt() then outputs it
/// </summary>
/// <returns></returns>
        public static int MainMenu()
        {
            int userOption;
            Console.WriteLine("\n----Welcome to Smart Shop.----");
                do
                {
                    Console.WriteLine("Please Log In or Create a User.");
                    Console.WriteLine("\n1: Log In/Switch user\n2: Create User\n3: View Shopping Menu\n4: --Exit--You will be Logged out!\n");
                    userOption = WasUserChoiceInt(Console.ReadLine());
                    if(userOption > 4 || userOption < 1)
                    {
                        Console.WriteLine("Please use a Valid option\n");
                    }

                } while(userOption != 1 && userOption != 2 && userOption != 3 && userOption != 4);
            return userOption;
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
                Console.WriteLine("\nInvalid response");
                return -1; 
            }
            return result;

        }

/// <summary>
/// Decides The users options for Oder History annd location choices uses the WasUserChoiceInt() to insure ints are chosen
/// </summary>
/// <param name="customer"></param>
/// <param name="handles"></param>
/// <returns></returns>
        public static int LocaionOrOrderViewMenu(Customer customer)
        {
            int userOption; 
    
            Console.WriteLine($"\n-----Welcome {customer.Fname}------- ");
                do
                {
                    Console.WriteLine("\nWhat would you Like to do?");
                    Console.WriteLine("\n1: Choose a Location\n2: User Order History and Cart\n3: Exit");
                    userOption = WasUserChoiceInt(Console.ReadLine());
                    if(userOption > 3 || userOption < 1)
                    {
                        Console.WriteLine("Please use a Valid option\n");
                    }

                } while(userOption != 1 && userOption != 2 && userOption != 3);

            return userOption;
        }

        /// <summary>
        /// Handles the menu and choices for retreiving orders and customer data
        /// </summary>
        /// <param name="handles"></param>
        /// <returns></returns>
        public static int OrderService()
        {
          int userOption = 0;
            do
                {
                    Console.WriteLine("What would you Like to do?");
                    Console.WriteLine("\n1: View current user Order History\n2: View current user Cart\n3: Search Customers by username\n4: Display Location History \n5: ---Exit---");
                    userOption = WasUserChoiceInt(Console.ReadLine());
                    if(userOption > 5 || userOption < 1)
                    {
                        Console.WriteLine("\nPlease use a Valid option");
                    }

                } while(userOption != 1 && userOption > 5);
            return userOption;

        }
        
    }
}