using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2._2.Unit
{
    class Blackjack
    {
        static private List<string> cards;
        private Player[] players;
        static internal bool gameIsOn;

        public Blackjack(int playerCount)
        {            
            cards = new List<string>{ "Ace", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2",
                                      "Ace", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2",
                                      "Ace", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2",
                                      "Ace", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2"};
            gameIsOn = true;
            players = new Player[5];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player("Player" + i);
            }
        }

        static public string TakeCard()
        {
            Random rnd = new Random();
            
            lock (cards)
            {
                string card = cards[rnd.Next(cards.Count - 1)];
                cards.Remove(card);
                return card;
            }
        }
    }
}
