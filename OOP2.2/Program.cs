using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2._2.Unit;

namespace OOP2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                Console.Clear();
                Blackjack game = new Blackjack(5);
                Console.ReadKey();
            }
        }
    }
}