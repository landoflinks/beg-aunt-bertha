using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beg_aunt_bertha
{
    /* This class contains all of the actions for the main game loop.
     * It primarily exists to free the main program of bloat. */
    class Actions : GameData
    {
        #region GameCommands 
        // This method lists commands for the main game loop.
        public void GameCommands()
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

        #region Main Actions

        #region Outside
        /* This method details what was done outside. 
        A number generator determines the outcome. */
            public void Outside()
                {
                    // If the weather is rainy, skip any outside activities.
                    if (Weather == "Thunderstorm" || Weather == "Light Rain")
                    {
                        Console.WriteLine("Aunt Bertha says: 'You can't go outside! It's raining!'");
                        Boredom += 1;
                    }
                    else
                    {
                        int outsideNum;
                        Random rand = new Random();
                        outsideNum = rand.Next(1, 6);

                        switch (outsideNum)
                        {
                            case 1:

                                break;
                            case 2:

                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                        }
                    }
                    
             }
        #endregion
        #endregion
    }
}
