using System;

namespace beg_aunt_bertha
{
    class Program
    {

        #region Main Method
        static void Main(string[] args)
        {
            string answer;
            GameData stats = new GameData();
            Pause pauseMenu = new Pause();

            Console.WriteLine("Welcome to Beg Aunt Bertha.");
            // Create main game loop command list

            // Setting pre-game stats
            stats.BadSeed = stats.SetDifficulty();
            stats.Weather = stats.SetWeather();
            stats.BerthaStatus = stats.SetBerthaStatus();

            Console.WriteLine("Bertha's Status: " + stats.BerthaStatus);
            
            // Main game loop

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
        #endregion
    }
}
