using System;

namespace RpsGame_NoDb
{
    /*class Player 
    {

        public Player(){}

        public Player(string fname = "null", string lname = "null")
        {
            this.Fname = fname;
            this.Lname = lname;

        }

        private Guid playerId = Guid.NewGuid();
        public Guid PlayerId
        {
            get
            {
                return playerId;
            }
        }

        private int numWins;
        private int numLosses;
        private string fName;
        public string Fname
        {
            get { return fName; }
            set
            {
                if (value is string && value.Length < 20 && value.Length > 0)
                {
                    fName = value;
                }
                else
                {
                    throw new Exception("The player name you sent is no valid");
                }
            }
        }

        private string lName;
        public string Lname
        {
            get { return lName; }
            set
            {
                if (value is string && value.Length < 20 && value.Length > 0)
                {
                    lName = value;
                }
                else
                {
                    throw new Exception("The player name you sent is no valid");
                }
            }
        }






        public void AddWin()
        {
            numWins++;
        }

         public void AddWin(int x)
        {
            numWins =+ x;
        }

        public void AddLoss()
        {
            numLosses++;
        }

        public int[] GetWinLossRecord()
        {
            int[] winsAndLosses = new int[2]; // create an array to hole the num of wins and losses

            winsAndLosses[0] = numWins; // put in the wins and losses
            winsAndLosses[1] = numLosses;

            return winsAndLosses; // return the array.
        }





    }*/
    public class Player
    {

        private Guid playerId = Guid.NewGuid();
        public Guid PlayerId
        {
            get => playerId;
        }

        private string fname;
        public string FirstName
        {
            get => fname;
            set
            {
                if (value is string && value.Length < 20 && value.Length > 1)
                {
                    fname = value;
                }
                else
                {
                    throw new Exception("Name you entered isn't valid.");
                }
            }
        }
        private string lname;
        public string LastName
        {
            get => lname;
            set
            {
                if (value is string && value.Length < 20 && value.Length > 1)
                {
                    lname = value;
                }
                else
                {
                    throw new Exception("Name you entered isn't valid.");
                }
            }
        }
        private int numWins;
        private int numLosses;

        public Player(string fname = null, string lname = null)
        {
            this.fname = fname;
            this.lname = lname;
        }
        public void AddWin()
        {
            numWins++;
        }

        public void AddLoss()
        {
            numLosses++;
        }

        public Array GetWinLossRecord()
        {
            int[] record = new int[2];
            record[0] = numWins;
            record[1] = numLosses;
            return record;
        }


    }
}