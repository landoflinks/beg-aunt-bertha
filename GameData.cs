using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beg_aunt_bertha
{
    // This class will be subject to a lot of changes as the game evolves. 
    // It is possible that it will be split into more than one class.
    class GameData
    {
        // Variables
        TimeSpan currentTime = new TimeSpan(); // Tracks current time in game.
        int badSeed; // Controls Aunt Bertha's difficulty.
        int boredom; // Tracks the player's boredom level. 
        int anger; // Aunt Bertha's tolerance of the player's antics.
        string berthaStatus; // Aunt Bertha's current status. 
        string weather; // Set at the beginning and (for now) changes halfway through the game.
    }
}
