
using System.Collections.Generic;
using System;

namespace RpsGame_NoDb
{
    /*class Match
    {
        private Guid matchId = Guid.NewGuid();
        public Guid MatchId { get { return matchId; } }

        public Player Player1 { get; set; } // always the computer
        public Player Player2 { get; set; } // always the user.

        public List<Round> Rounds = new List<Round>();

        private int p1RoundWins { get; set; } // how many rounds has the player won?
        private int p2RoundWins { get; set; }
        private int ties { get; set; }

        //Methods
        /// <summary>
        /// This is discription of the method called round winner
        /// This player takes an optional Player object and increments the number of round wins
        /// no arguments is equal to a tie
        /// </summary>
        /// <param name="p"></param>
        public void RoundWinner(Player p = null)
        {
            if (p.PlayerId == Player1.PlayerId)
            {
                p1RoundWins++;
            }
            else if (p.PlayerId == Player2.PlayerId)
            {
                p2RoundWins++;

            }
            else
            {
                ties++;
            }
        }

        public Player MatchWinner()
        {
            if (p1RoundWins == 2)
            {
                return Player1;
            }
            else if (p2RoundWins == 2)
            {
                return Player2;
            }
            else
            {
                return null;
            }
        }

    }*/
     public class Match
    {
        private Guid matchId = Guid.NewGuid();
        public Guid MatchId
        {
            get => matchId;
        }
        public Player Bot { get; set; } //computer
        public Player User { get; set; } //user

        public List<Round> Rounds = new List<Round>();

        private int userRoundWins;
        public int UserRoundWins { get; set; }

        private int botRoundWins;
        public int BotRoundWins { get; set; }
        private int ties { get; set; }

        public void RoundWinner()
        {
            ties++;
        }
        public void RoundWinner(Player p = null)
        {
            if (p.PlayerId == Bot.PlayerId)
            {
                BotRoundWins++;
            }
            else if (p.PlayerId == User.PlayerId)
            {
                UserRoundWins++;
            }
            else
            {
                ties++;
            }
        }

        public Player MatchWinner()
        {
            if (BotRoundWins == 2)
            {
                return Bot;
            }
            else if (UserRoundWins == 2)
            {
                return User;
            }
            else
            {
                return null;
            }
        }

    }


}
