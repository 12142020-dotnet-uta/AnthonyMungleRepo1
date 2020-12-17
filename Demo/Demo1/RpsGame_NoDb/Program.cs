using System;
using System.Collections.Generic;

namespace RpsGame_NoDb
{
   /* class Program
    {
        static void Main(string[] args)
        {

            List<Player> players = new List<Player>();
            List<Match> matches = new List<Match>();
            List<Round> rounds = new List<Round>();

            //Creates th computer that everyone plays against
            Player p1 = new Player()
            {
                Fname = "Max",
                Lname = "Headroom"
            };

            players.Add(p1);



            Console.WriteLine("This is The Official Batch Rock-Paper-Scissors Game");
            Console.WriteLine("\nPlease enter your First and Last name.\n");
            
            string[] userNamesArray;
            do{

            string userNames = Console.ReadLine();
            userNamesArray = userNames.Split(' ');
           
            }while(userNamesArray[0] == "");
       
            Player p2 = new Player();

            if(userNamesArray.Length == 1)
            {
                p2.Fname = userNamesArray[0];
            }

            if(userNamesArray.Length > 1)
            {
                p2.Fname = userNamesArray[0];
                p2.Lname = userNamesArray[1];
            } 

            players.Add(p2);
            Match match = new Match();
            match.Player1 = p1;
            match.Player2 = p2;
            Round round = new Round();

            //user will choose Rock, paper, or sciccors
            Choice userChoice; // declare these two variables to be used int he do/while loop
            bool userResponseParsed;
            do
            {
                Console.WriteLine($"Welcome, {p2.Fname} Please choose Rock, Paper, or Scissors by typing 0, 1, 2 and hitting enter.");
                Console.WriteLine("\t0. Rock \n\t1. Paper \n\t2. Scissors");
                // Console.WriteLine("2. Paper");
                // Console.WriteLine("3. Scissors");

                string userResponse = Console.ReadLine();   // read the users unput

                userResponseParsed = Choice.TryParse(userResponse, out userChoice);    // parse the users input to am int

                if (userResponseParsed == false || ((int)userChoice > 2 || (int)userChoice < 0))  // give a message if the users unput was invalid
                {
                    Console.WriteLine("Your response is invalid.");
                }

            } while (userResponseParsed == false || (int)userChoice > 3 || (int)userChoice < 0);  // state conditions for if we will repeat the loop

            // Console.WriteLine($"Congrats you entered a correct number. It is {userChoice}.");
            Console.WriteLine("Starting the game...");

            Random randonNumber = new Random(10); // create a randon number object
            Choice computerChoice = (Choice)randonNumber.Next(0, 3);   // get a randon number 1, 2, or 3.

            round.Player1Choice = computerChoice;
            round.Player2Choice = userChoice;

            Console.WriteLine($"The computer choice is => {computerChoice}");

            // compare the numebrs to see who won.
            if (userChoice == computerChoice)   // is the playes tied
            {
                Console.WriteLine("This game was a tie");
                //rounds,winninPlayer is default null
                rounds.Add(round);
                match.Rounds.Add(round);
                match.RoundWinner();
            }
            else if (((int) userChoice == 1 && (int)computerChoice == 0) || // if the user won
                ((int)userChoice == 2 && (int)computerChoice == 1) ||
                ((int)userChoice == 0 && (int)computerChoice == 2))
            {
                Console.WriteLine("Congrats. You (the user) WON!.");
                round.WinningPlayer = p2;
                rounds.Add(round);
                match.Rounds.Add(round);
                match.RoundWinner(p2);
            }
            else
            {
                Console.WriteLine("We're sorry. The computer won.");
                round.WinningPlayer = p1;
                rounds.Add(round);
                match.Rounds.Add(round);
                match.RoundWinner(p1);
            }

            foreach(Round round1 in rounds)
            {
                Console.WriteLine($"\n Round - \nThe GUID is {round.RoundId}.\n P1 Choice is {round.Player1Choice} \n P2 Choice is {round1.Player2Choice} \n The Winning player is {round.WinningPlayer.Fname}\n");
            }

        }
    }*/

    class Program
    {

        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Round> rounds = new List<Round>();
            List<Match> matches = new List<Match>();
            int roundNumber = 1;

            Player bot = new Player()
            {
                FirstName = "bot",
                LastName = "player"
            };
            players.Add(bot);

            while (true)
            {


                Console.WriteLine("----- Main Menu -----");
                Console.WriteLine("\nPlease choose an option.");
                Console.WriteLine("\t1. Login \n\t2. Quit");

                if (!int.TryParse(Console.ReadLine(), out int menuResponse) || menuResponse < 1 || menuResponse > 2)
                {
                    Console.WriteLine("Invalid input. Pick option 1 or 2.");
                    continue;
                }
                else if (menuResponse == 2)
                {
                    break;
                }

                Console.WriteLine("----- Login -----");
                Console.Write("\nEnter first name: ");
                string firstName = Console.ReadLine();
                Console.Write("\nEnter last name:");
                string lastName = Console.ReadLine();
                Player user = new Player(firstName, lastName);

                if (!PlayerExists(user, players))
                {
                    Console.WriteLine("User created.");
                    players.Add(user);
                }


                while (true)
                {
                    Console.WriteLine("----- Game Menu -----");
                    Console.WriteLine("\nPlease choose an option.");
                    Console.WriteLine("\t1. Play Game\n\t2. Logout");
                    if (!int.TryParse(Console.ReadLine(), out int gameMenuResponse) || gameMenuResponse < 1 || gameMenuResponse > 2)
                    {
                        Console.WriteLine("Invalid input. Pick option 1 or 2.");
                        continue;
                    }
                    else if (gameMenuResponse == 2)
                    {
                        break;
                    }
                    PlayGame();

                }



                void PlayGame()
                {
                    Match match = new Match();

                    match.Bot = bot;
                    match.User = user;

                    while (true)
                    {

                        Round round = new Round();

                        Choice userSelection;
                        int botSelection;
                        string userResponse;

                        Console.WriteLine($"\nStarting Round {roundNumber}...");
                        Console.WriteLine("\nPlease choose Rock, Paper, or Scissors by typing 1, 2, or 3 and hitting enter.");
                        Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");
                        userResponse = Console.ReadLine();

                        // parse the users input to an int

                        if (!Choice.TryParse(userResponse, out userSelection) || (int)userSelection > 3 || (int)userSelection < 1) // give a message if the users input was invalid
                        {
                            Console.WriteLine("Your response is invalid.");
                            continue;
                        }
                        round.UserChoice = userSelection;

                        Random rnd = new Random();
                        botSelection = rnd.Next(1, 4);

                        round.BotChoice = (Choice)botSelection;

                        switch (round.UserChoice)
                        {
                            case Choice.Rock:
                                switch (round.BotChoice)
                                {
                                    case Choice.Rock:
                                        Console.WriteLine("Tie. You chose rock. Bot chose rock.");
                                        match.RoundWinner();
                                        break;
                                    case Choice.Paper:
                                        Console.WriteLine("Lose. You chose rock. Bot chose paper.");
                                        round.WinningPlayer = bot;
                                        match.RoundWinner(bot);
                                        break;
                                    default:
                                        Console.WriteLine("Win. You chose rock. Bot chose scissors.");
                                        round.WinningPlayer = user;
                                        match.RoundWinner(user);
                                        break;
                                }
                                break;
                            case Choice.Paper:
                                switch (round.BotChoice)
                                {
                                    case Choice.Rock:
                                        Console.WriteLine("Win. You chose paper. Bot chose rock.");
                                        round.WinningPlayer = user;
                                        match.RoundWinner(user);
                                        break;
                                    case Choice.Paper:
                                        Console.WriteLine("Tie. You chose paper. Bot chose paper.");
                                        match.RoundWinner();
                                        break;
                                    default:
                                        Console.WriteLine("Lose. You chose paper. Bot chose scissors.");
                                        round.WinningPlayer = bot;
                                        match.RoundWinner(bot);
                                        break;
                                }
                                break;
                            default:
                                switch (round.BotChoice)
                                {
                                    case Choice.Rock:
                                        Console.WriteLine("Lose. You chose scissors. Bot chose rock.");
                                        round.WinningPlayer = bot;
                                        match.RoundWinner(bot);
                                        break;
                                    case Choice.Paper:
                                        Console.WriteLine("Win. You chose scissors. Bot chose paper.");
                                        round.WinningPlayer = user;
                                        match.RoundWinner(user);
                                        break;
                                    default:
                                        Console.WriteLine("Tie. You chose scissors. Bot chose scissors.");
                                        match.RoundWinner();
                                        break;
                                }
                                break;
                        }
                        rounds.Add(round);
                        roundNumber++;
                        match.Rounds.Add(round);

                        if (match.UserRoundWins == 2 || match.BotRoundWins == 2)
                        {
                            matches.Add(match);
                            Player winner = match.MatchWinner();
                            Console.Write($"\nMatch winner: {winner.FirstName}");
                            PrintStats();

                            Console.WriteLine("\n\nWould you like to play again?\n\tType y for Yes\n\tType n for No\n");
                            string playAgain = Console.ReadLine(); // User input and add into playAgain
                            if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase) || playAgain.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            {
                                match = new Match();
                                match.Bot = bot;
                                match.User = user;
                                roundNumber = 1;
                                continue;
                            }
                            else
                            {
                                // Console.WriteLine("Players List:");
                                // foreach (Player player1 in players)
                                // {
                                //     Console.WriteLine($"Player: {player1.PlayerId} | Player Name: {player1.FirstName}");
                                // }
                                // Console.WriteLine("Rounds List:");
                                // foreach (Round round1 in rounds)
                                // {
                                //     Console.WriteLine($"Round: {round1.RoundId}");
                                // }
                                // Console.WriteLine("Matches List:");
                                // foreach (Match match1 in matches)
                                // {
                                //     Console.WriteLine($"Match ID: {match1.MatchId} | Match winner: {match1.MatchWinner().FirstName}");
                                // }
                                Console.WriteLine($"\nTotal matches played: {matches.Count}");
                                Console.WriteLine("\nGood bye.");
                                break;
                            }

                        }
                        else
                        {
                            continue;
                        }

                    }
                }





            }

            bool PlayerExists(Player p, List<Player> l)
            {
                foreach (Player pl in l)
                {
                    if (pl.FirstName == p.FirstName && pl.LastName == p.LastName)
                    {
                        Console.WriteLine("User already exists. Logging In.");
                        return true;
                    }
                }
                return false;
            }

            void PrintStats()
            {
                Console.WriteLine("\nRounds List:");
                int counter = 1;
                foreach (Round round1 in rounds)
                {

                    if (round1.WinningPlayer == null)
                    {
                        Console.WriteLine($"Round #{counter}: Was a tie");
                    }
                    else
                    {
                        Console.WriteLine($"Round #{counter}: {round1.WinningPlayer.FirstName}");
                    }
                    counter++;
                }
            }
        }




    }


}
