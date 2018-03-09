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
            Actions action = new Actions();
            Pause pauseMenu = new Pause();

            Console.WriteLine("Welcome to Beg Aunt Bertha.");
            // Create main game loop command list

            // Setting pre-game stats
            stats.BadSeed = stats.SetDifficulty();
            stats.Weather = stats.SetWeather();
            stats.BerthaStatus = stats.SetBerthaStatus();
            action.GameCommands();
            Console.WriteLine("Current Time: " + stats.CurrentTime);
            Console.WriteLine("Bertha's Status: " + stats.BerthaStatus);

            // Main game loop
            Console.Write("Enter in a value: ");
            answer = Convert.ToString(Console.ReadLine()).ToUpper();

            while (answer != "Q")
            {
                switch (answer)
                {
                    case "A":
                        // Shows available commands.
                        action.GameCommands();
                        break;
                    case "P":
                        // Used to access the Pause Menu.
                        pauseMenu.PauseMenu(stats);
                        break;
                }

                Console.WriteLine("Bertha's Status: " + stats.BerthaStatus);
                Console.Write("Enter in a command: ");
                answer = Convert.ToString(Console.ReadLine()).ToUpper();
            }

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
        #endregion
    }
}
