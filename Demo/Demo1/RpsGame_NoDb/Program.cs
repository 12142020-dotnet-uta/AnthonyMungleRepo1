using System;

namespace RpsGame_NoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            
//Versoin 1
            //Console.WriteLine(userResponse);
          /*   int userChoice;
             bool userResponseParsed;
            do
            {
                Console.WriteLine("Please Choose Rock, Paper, or scissors by typing 1, 2, 3 and hitting Enter.");
                Console.WriteLine("\t1. Rock\n\t2. Paper\n\t3. Scissors");
                string userResponse = Console.ReadLine(); //Takes in users input
            
              
                userResponseParsed = int.TryParse(userResponse, out userChoice);

                if(userResponseParsed == false || (userChoice > 3 || userChoice < 1))
                {
                    Console.WriteLine("Your response is invalid.");
                }


            } while(userResponseParsed == false || userChoice > 3 || userChoice < 1);
            
            Console.WriteLine($"You chose a number. It is a {userChoice}.");

            Random randomNumber = new Random(10); //Creates a random number object
            int computerChoice = randomNumber.Next(1,4); //Get a random number between 1, 2, 3

            Console.WriteLine($"The computers choice is {computerChoice}");

            if(userChoice == computerChoice) //If the players tie
            {
                Console.WriteLine("It is a tie");
            }

            else if((userChoice == 2 && computerChoice == 1 )|| //if the user won
            (userChoice == 3 && computerChoice == 2) ||
            (userChoice == 1 && computerChoice == 3))
            {
                Console.WriteLine("Congrats You Won!");
            }

            else //if the computer won
            {
                Console.WriteLine("We're sorry. The computer won.");
            }
            */
        // Version 2
            Console.WriteLine("This is The Group 2 Awesome Rock-Paper-Sissors Game!\n");
            while(true) {
                int userSelection;
                bool userResponseParsed;
                int botSelection;
                Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 Aand hiiting enter.");
                Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");
                var userResponse = Console.ReadLine(); //var will make it the proper type 'string'
                userResponseParsed = int.TryParse(userResponse, out userSelection);    // parse the users input to an int
                if(userResponseParsed == false || userSelection > 3 || userSelection < 1) // give a message if the users input was invalid
                {
                    Console.WriteLine("Your response is invalid.");
                    continue;
                }
                Console.WriteLine("Starting the game...");
                Random rnd = new Random();
                botSelection = rnd.Next(1, 4);
                switch (userSelection)
                {
                    case 1:
                        switch (botSelection)
                        {
                            case 1: Console.WriteLine("Tie. You chose rock. Bot chose rock."); break;
                            case 2: Console.WriteLine("Lose. You chose rock. Bot chose paper."); break;
                            default: Console.WriteLine("Win. You chose rock. Bot chose scissors."); break;
                        }
                        break;
                    case 2:
                        switch (botSelection)
                        {
                            case 1: Console.WriteLine("Win. You chose paper. Bot chose rock."); break;
                            case 2: Console.WriteLine("Tie. You chose paper. Bot chose paper."); break;
                            default: Console.WriteLine("Lose. You chose paper. Bot chose scissors."); break;
                        }
                        break;
                    default:
                        switch (botSelection)
                        {
                            case 1: Console.WriteLine("Lose. You chose scissors. Bot chose rock."); break;
                            case 2: Console.WriteLine("Win. You chose scissors. Bot chose paper."); break;
                            default: Console.WriteLine("Tie. You chose scissors. Bot chose scissors."); break;
                        }
                        break;
                    }
                Console.WriteLine("\nWould you like to play again?\n\tType y for Yes\n\tType n for No\n");
                string playAgain = Console.ReadLine(); // User input and add into playAgain
                if(playAgain == "y") {
                    continue;
                } else {
                    Console.WriteLine("\nGood bye.");
                    break;
                }
            }
    
        }

    }
}    