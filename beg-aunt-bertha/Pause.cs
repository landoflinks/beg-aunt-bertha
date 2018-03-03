using System;

namespace beg_aunt_bertha
{
    /* This class holds the methods for the "paused" state of the game.
     * It is in place to help unclutter the main program. */
    class Pause
    {
        #region PauseMenu
        public static void PauseMenu(GameData stats)
        {
            string answer;

            Console.WriteLine("~Pause Menu~");
            HelpText();
            Console.Write("Enter in a value: ");
            answer = Convert.ToString(Console.ReadLine()).ToUpper();

            while (answer != "E")
            {
                switch (answer)
                {
                    case "O":
                        // Calls the self-explanatory Objective method.
                        Objective();
                        break;
                    case "H":
                        // Calls the HelpText method to display helpful commands.
                        HelpText();
                        break;
                    case "S":
                        // Game stats display here.
                        stats.DisplayStats();
                        break;
                }

                Console.WriteLine("Bertha's Status: " + stats.BerthaStatus);
                Console.Write("Enter in a command: ");
                answer = Convert.ToString(Console.ReadLine()).ToUpper();
            }
        }
        #endregion

        #region HelpText
        public static void HelpText()
        {
            // This method displays helpful commands.
            Console.WriteLine("The following values can be keyed in:");
            Console.WriteLine("O - Read the objective for the game.");
            Console.WriteLine("S - Check the current stats in the game.");
            Console.WriteLine("H - Display helpful commands.");
            Console.WriteLine("E - Exit the Pause Menu.");
        }

        #endregion

        #region Objective
        public static void Objective()
        {
            // This explains the objective of the game.
            Console.WriteLine("It's the first day of summer vacation. You're looking forward " +
                            "to an uninterrupted day full of video game fun! But then, disaster strikes. " +
                            "Your mom gets called into work. Guess who has volunteered to babysit you? " +
                            "Your worst nightmare, your least favorite relative...your great-aunt Bertha!");
            Console.WriteLine("");
            Console.WriteLine("Aunt Bertha is one of THOSE old ladies. You know the type...." +
                "She thinks that video games rot your brain, contribute to all sorts of " +
                "problems in society, and in general shouldn't exist.");
            Console.WriteLine("");
            Console.WriteLine("She's also quite boring. Aunt Bertha is quite content to sit " +
                "in the living room most of the day watching daytime soap operas or poring " +
                "through stale old romance novels. She never does anything interesting!");
            Console.WriteLine("");
            Console.WriteLine("Your mission, should you choose to accept it, is to salvage " +
                "what precious game time you can during your afternoon. Through " +
                "stealth or rebellion, you will play games! And, if neither of those work, " +
                "you will have to beg Aunt Bertha!");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        #endregion
    }
}
