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
        TimeSpan currentTime; // Tracks current time in game.
        int badSeed; // Controls Aunt Bertha's difficulty.
        int boredom; // Tracks the player's boredom level. 10 = insanity by boredom/game over.
        int anger; // Aunt Bertha's tolerance of the player's antics. 10 = early bedtime/game over.
        string berthaStatus; // Aunt Bertha's current status. 
        string weather; // Set at the beginning and (for now) changes halfway through the game.

        public GameData() // Sets defaults when game starts.
        {
            currentTime = new TimeSpan(13, 00, 00);
            badSeed = 1;
            boredom = 1;
            anger = 1;
            berthaStatus = "Watching TV";
            weather = "Sunny";
        }

        public TimeSpan CurrentTime { get; set; }
        public int BadSeed { get; set; }
        public int Boredom { get; set; }
        public int Anger { get; set; }
        public string BerthaStatus { get; set; }
        public string Weather { get; set; }
    }
}
