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

            answer = Convert.ToString(Console.Read());

            while (answer != "Q")
            {
                answer = Convert.ToString(Console.Read());
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
