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
        private TimeSpan currentTime; // Tracks current time in game.
        private int badSeed; // Controls Aunt Bertha's difficulty.
        private int boredom; // Tracks the player's boredom level. 10 = insanity by boredom/game over.
        private int anger; // Aunt Bertha's tolerance of the player's antics. 10 = early bedtime/game over.
        private string berthaStatus; // Aunt Bertha's current status. 
        private string weather; // Set at the beginning and (for now) changes halfway through the game.

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

        //////// Class methods ////////

        /* This method randomly determines the weather in the game. For now, it is only
           set at the beginning and changed halfway through. It is summer, so the following
           weather effects apply: 1 - Sunny; 2 - Cloudy; 3 - Light Rain; 4 - Thunderstorm. */
        public string SetWeather()
        {
            string weather = "";
            int randomNum;
            Random rand = new Random();
            randomNum = rand.Next(1,4);

            switch (randomNum)
            {
                case 1:
                    weather = "Sunny";
                    break;
                case 2:
                    weather = "Cloudy";
                    break;
                case 3:
                    weather = "Light Rain";
                    break;
                case 4:
                    weather = "Thunderstorm";
                    break;
            }
            return weather;
        }

        /* This method sets Bertha's difficulty by polling the player about
           their favorite games. */
        public int SetDifficulty()
        {
            int difficulty = 1, value1, value2, value3;

            return difficulty;
        }
    }
}