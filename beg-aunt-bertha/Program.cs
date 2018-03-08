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

            Console.WriteLine("Welcome to Beg Aunt Bertha.");
            // Create main game loop command list

            // Setting pre-game stats
            stats.BadSeed = stats.SetDifficulty();
            stats.Weather = stats.SetWeather();
            stats.BerthaStatus = stats.SetBerthaStatus();
            GameCommands();
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
                        GameCommands();
                        break;
                    case "P":
                        // Used to access the Pause Menu.
                        Pause pauseMenu = new Pause();
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

        #region GameCommands
        // This method lists commands for the main game loop. It'll change a lot.
        private static void GameCommands()
        {
            Console.WriteLine("The following values can be entered:");
            Console.WriteLine("O - Go outside");
            Console.WriteLine("R - Read in your room");
            Console.WriteLine("T - Attempt to watch TV");
            Console.WriteLine("S - Sit around bored");
            Console.WriteLine("V - Sneak off and play video games");
            Console.WriteLine("A - Show available commands");
            Console.WriteLine("P - Access the pause menu");
            Console.WriteLine("Q - Quit the game");
        }
        #endregion
    }
}
