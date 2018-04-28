using System;
using System.Threading;

namespace beg_aunt_bertha
{
    class Program
    {

        #region Main Method
        static void Main(string[] args)
        {
            string answer, play;
            Pause pauseMenu = new Pause();

            Console.Write("Play Beg Aunt Bertha? (Y/N): ");
            play = Convert.ToString(Console.ReadLine()).ToUpper();

            while (play != "N")
            {
                // Set new instances of these two classes on each game reset.
                TimeSpan newTime = new TimeSpan();
                Actions action = new Actions();

                Console.WriteLine("Welcome to Beg Aunt Bertha.");

                // Setting pre-game action
                action.BadSeed = action.SetDifficulty();
                action.Weather = action.SetWeather();
                action.BerthaStatus = action.SetBerthaStatus();

                action.GameCommands();
                Console.WriteLine("Current Time: " + action.CurrentTime);
                Console.WriteLine("Bertha's Status: " + action.BerthaStatus);

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
                            newTime = action.Outside(action.CurrentTime, action.Weather);
                            break;
                        case "R":
                            // Calls the Read() method.
                            newTime = action.Read(action.CurrentTime);
                            break;
                        case "T":
                            newTime = action.Television(action.CurrentTime, action.BerthaStatus);
                            break;
                        case "S":
                            newTime = action.DieFromBoredom(action.CurrentTime);
                            break;
                        case "V":
                            newTime = action.VideoGames(action.CurrentTime, action.BerthaStatus);
                            break;
                        case "P":
                            // Used to access the Pause Menu.
                            newTime = action.CurrentTime; // Called to preserve the TimeSpan value.
                            pauseMenu.PauseMenu(action);
                            break;
                    }

                    // Checks the current time and sets in-game events into motion accordingly.
                    action.CheckTime();

                    if (action.Exit == true)
                    {
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Current Time: " + newTime); //action.CurrentTime
                    Console.WriteLine("Bertha's Status: " + action.BerthaStatus);
                    Console.Write("Enter in a command: ");
                    answer = Convert.ToString(Console.ReadLine()).ToUpper();
                    action.CurrentTime = newTime;
                }
                Console.Write("Play again? (Y/N): ");
                play = Convert.ToString(Console.ReadLine()).ToUpper();
            }

            Console.WriteLine("Thanks for playing!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        #endregion
    }
}
