using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2._2.Unit
{
    class Player
    {
        public string name;
        public int points;
        public Task task;
        private Random rnd;
        public bool readyForEnd;        
        
        public Player(string name)
        {
            this.name = name;
            rnd = new Random();
            points = 0;
            readyForEnd = false;
            task = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (points < 17)
                    {
                        points += CardToPoints(Blackjack.TakeCard());
                        task.Wait(1500);
                    }
                    if (points > 17 && points < 21)
                    {
                        task.Wait(1000);
                        if (rnd.Next(1000) > 700)
                        {                            
                            points += CardToPoints(Blackjack.TakeCard());
                            task.Wait(1000);
                        }
                        Console.WriteLine("{0} points: {1}", name, points);
                        readyForEnd = true;
                    }
                    if (points > 21)
                    {
                        Console.WriteLine("{0} exite. >21", name);
                        readyForEnd = true;
                    }
                    if (points == 21)
                    {
                        Console.WriteLine("{0} win.", name);
                        readyForEnd = true;
                        Blackjack.gameIsOn = false;
                    }
                } while (Blackjack.gameIsOn && !readyForEnd);
            });
        }

        private int CardToPoints(string card)
        {
            if (Char.IsDigit(card[0]))
            {
                Console.WriteLine("{0} is taking card. Card is {1}", name, card);
                return Convert.ToInt16(card);
            }
            switch (card)
            {
                case "Ace":
                    Console.WriteLine("{0} is taking card. Card is {1}", name, card);
                    return 11;
                case "K":
                case "Q":
                case "J":
                    Console.WriteLine("{0} is taking card. Card is {1}", name, card);
                    return 10;
                default:
                    return -1;
            }
        }
    }
}
