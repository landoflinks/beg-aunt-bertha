using System;

namespace beg_aunt_bertha
{
    class Program
    {

        #region Main Method
        static void Main(string[] args)
        {
            string answer;
            TimeSpan newTime = new TimeSpan();
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
                    case "O":
                        // Calls the Outside() method.
                        newTime = action.Outside(stats.CurrentTime);
                        break;
                    case "R":
                        // Calls the Read() method.
                        newTime = action.Read(stats.CurrentTime);
                        break;
                    case "T":
                        newTime = action.Television(stats.CurrentTime);
                        break;
                    case "S":
                        newTime = action.DieFromBoredom(stats.CurrentTime);
                        break;
                    case "V":
                        newTime = action.VideoGames(stats.CurrentTime);
                        break;
                    case "P":
                        // Used to access the Pause Menu.
                        pauseMenu.PauseMenu(stats);
                        break;
                }

                // Check the Anger and Boredom to make sure they are not out of bounds.
                stats.CheckAnger(stats.Anger);
                stats.CheckBoredom(stats.Boredom);

                // Checks the current time and sets in-game events into motion accordingly.
                stats.CheckTime();

                Console.WriteLine();
                Console.WriteLine("Current Time: " + newTime); //stats.CurrentTime
                Console.WriteLine("Bertha's Status: " + stats.BerthaStatus);
                Console.Write("Enter in a command: ");
                answer = Convert.ToString(Console.ReadLine()).ToUpper();
                stats.CurrentTime = newTime;
            }

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
        #endregion
    }
}
