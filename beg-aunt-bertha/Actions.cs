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
        // This method lists commands for the main game loop. It'll change a lot.
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
    }
}
