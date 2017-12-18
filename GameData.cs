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
        public TimeSpan CurrentTime { get; set; }
        public int BadSeed { get; set; }
        public int Boredom { get; set; }
        public int Anger { get; set; }
        public string BerthaStatus { get; set; }
        public string Weather { get; set; }

        public GameData() // Sets defaults when game starts.
        {
            CurrentTime = new TimeSpan(1,0,0);
            BadSeed = 1;
            Boredom = 1;
            Anger = 1;
            BerthaStatus = "Watching TV";
            Weather = "Sunny";
        }
        
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
           their favorite games. An average is calculated between 1 and 4, with
           4 being the highest difficulty. */
        public int SetDifficulty()
        {
            decimal answer;
            int difficulty = 1;
            int[] value = new int[3];

            Console.WriteLine("Choose your three favorite game genres from the following list:");
            Console.WriteLine("1. Action/Adventure\n2. FPS/TPS\n3. Platformer\n4. Puzzle/Match 3" +
                                "\n5. MMORPG\n6. Fighting\n7. Racing\n8. Sports\n9. RPG" +
                                "\n10. RTS\n11. Simulation\n12. Edutainment");
            Console.Write("Enter the first number:");
            value[0] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number:");
            value[1] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the third number:");
            value[2] = Convert.ToInt32(Console.ReadLine());

            // Loop through, determine the value assigned to each genre, and add it to the difficulty. 
            for (int i = 0; i < 3; i++)
            {
                if(value[i] == 4 || value[i] == 8 || value[i] == 12)
                {
                    // 4 = Puzzle/Match 3, 8 = Sports, 12 = Edutainment. Not bad at all.
                    difficulty += 1;
                }
                else if(value[i] == 3 || value[i] == 7 || value[i] == 11)
                {
                    // 3 = Platformer, 7 = Racing, 11 = Simulation. Passable.
                    difficulty += 2;
                }
                else if (value[i] == 1 || value[i] == 9 || value[i] == 10)
                {
                    // 1 = Action/Adventure, 9 = RPG, 10 = RTS. What are you doing with your life?
                    difficulty += 3;
                }
                else
                {
                    // 2 = FPS/TPS, 5 = MMORPG, 6 = Fighting. You monster!
                    difficulty += 4;
                }
            }

            // Find the difficulty average.
            difficulty /= 3;
            answer = Math.Round(Convert.ToDecimal(difficulty), 0, MidpointRounding.AwayFromZero);

            switch (answer)
            {
                case 1:
                    Console.WriteLine("Aunt Bertha doesn't think your gaming habits are that bad.");
                    break;
                case 2:
                    Console.WriteLine("Aunt Bertha sometimes nags you to get a different hobby.");
                    break;
                case 3:
                    Console.WriteLine("Aunt Bertha thinks you can still be saved.");
                    break;
                case 4:
                    Console.WriteLine("Aunt Bertha believes you're a delinquent beyond redemption.");
                    break;
            }

            return Convert.ToInt32(answer);
        }

        public void DisplayStats()
        {
            Console.WriteLine("Current game stats:");
            Console.WriteLine("Current Time: " + Convert.ToString(CurrentTime) + 
                                "\nDifficulty: " + Convert.ToString(BadSeed) + 
                                "\nBoredom: " + Convert.ToString(Boredom) +
                                "\nBertha's Status: " + BerthaStatus +
                                "\nCurrent Weather: " + Weather);
        }
    }
}