using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beg_aunt_bertha
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;

            Console.WriteLine("Welcome to Beg Aunt Bertha.");
            Console.WriteLine("Type P to start the game.");
            Console.WriteLine("The following values can be keyed in at any time to do the following:");
            Console.WriteLine("O - Read the objective for the game.");
            Console.WriteLine("S - Check the player's status.");
            Console.WriteLine("Q - Quit the game.");

            Console.Write("Enter in a value to proceed: ");
            answer = Convert.ToString(Console.Read()).ToUpper();

            while (answer != "Q")
            {
                Console.Write("What will you do next? Enter in a command: ");
                answer = Convert.ToString(Console.Read()).ToUpper();
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
