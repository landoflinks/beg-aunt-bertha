﻿using System;

namespace beg_aunt_bertha
{
    /* The GameData class is where the stats and their related logic
     are stored. This class is subject to change and may even be split up. */
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

        #region SetWeather
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

        #endregion

        #region SetBerthaStatus
        /* This method sets Aunt Bertha's status using random number generation.
           It is called roughly every half hour in the main game. Some statuses will 
           affect Bertha's anger level. A better method of doing this may be devised later. */
        public string SetBerthaStatus()
        {
            string status = "";
            int randomNum;
            Random rand = new Random();
            randomNum = rand.Next(1, 6);

            switch (randomNum)
            {
                case 1:
                    status = "Watching TV";
                    break;
                case 2:
                    status = "Sleeping";
                    Anger -= 2;
                    break;
                case 3:
                    status = "Reading a bad romance novel";
                    Anger -= 1;
                    break;
                case 4:
                    status = "Bawling her eyes out over a predictable soap opera twist";
                    Anger += 1;
                    break;
                case 5:
                    status = "Nagging some poor cable worker over the phone";
                    Anger += 1;
                    break;
                case 6:
                    status = "Checking Facebook on mom's computer";
                    break;
            }

            // Anger cannot be below 1. This fixes that.
            CheckAnger(Anger);

            return status;
        }

        #endregion

        #region SetDifficulty
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
            value[0] = GameNumCheck(value[0]);
            Console.Write("Enter the second number:");
            value[1] = Convert.ToInt32(Console.ReadLine());
            // Check to make sure this value doesn't match the previous value.
            while (value[1] == value[0])
            {
                Console.Write("The value you entered matches the previous value. Please enter another:");
                value[1] = Convert.ToInt32(Console.ReadLine());
            }
            value[1] = GameNumCheck(value[1]);
            Console.Write("Enter the third number:");
            value[2] = Convert.ToInt32(Console.ReadLine());
            // Check to make sure this value doesn't match the previous values.
            while (value[2] == value[1] || value[2] == value[0])
            {
                Console.Write("The value you entered matches one of the previous values. Please enter another:");
                value[2] = Convert.ToInt32(Console.ReadLine());
            }
            value[2] = GameNumCheck(value[2]);

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

            // For now, BadSeed contributes to Bertha's anger level.
            Anger += BadSeed;

            return Convert.ToInt32(answer);
        }

        #endregion

        #region DisplayStats
        // Displays current game stats.
        public void DisplayStats()
        {
            Console.WriteLine("Current game stats:");
            Console.WriteLine("Current Time: " + Convert.ToString(CurrentTime) + 
                                "\nDifficulty: " + Convert.ToString(BadSeed) + 
                                "\nBoredom: " + Convert.ToString(Boredom) +
                                "\nBertha's Status: " + BerthaStatus +
                                "\nCurrent Weather: " + Weather);
        }
        #endregion

        #region GameNumCheck
        // This simple method checks to make sure none of the genre numbers entered is above twelve.
        private int GameNumCheck(int num)
        {
             while (num > 12)
             {
                Console.Write("The number you entered is greater than 12. Please enter a number under 12:");
                num = Convert.ToInt32(Console.ReadLine());
             }
            return num;
        }
        #endregion

        #region CheckAnger
        // Checks Aunt Bertha's anger. Anger can't be less than 1. Anger = 10 is a game over!
        public int CheckAnger(int rage)
        {
            if (rage < 1)
            {
                rage = 1;
            }

            if (rage <= 10)
            {
                rage = 10;
                // Call GameOver function.
                GameOver();
            }

            return rage;
        }
        #endregion

        #region CheckBoredom
        // Checks the player's boredom. Boredom can't be less than 1. Boredom = 10 is a game over!
        public int CheckBoredom(int blah)
        {
            if (blah < 1)
            {
                blah = 1;
            }

            if (blah <= 10)
            {
                blah = 10;
                // Call GameOver function.
                GameOver();
            }

            return blah;
        }
        #endregion

        #region GameOver
        // Handles a game over.
        public void GameOver()
        {
            // Check if Bertha is supremely ticked.
            if (Anger == 10)
            {
                Console.WriteLine("You have REALLY pushed Aunt Bertha to her limit!");
                Console.WriteLine("She forces you to stay in the same room as her for the rest of the afternoon, " +
                    "and you aren't allowed to do ANYTHING except stare at the wall and think about 'what you've done'.");
                Console.WriteLine("Aunt Bertha doesn't take her eyes off of you for ONE SECOND.");
                Console.WriteLine("Better luck next time!");
                Console.WriteLine("Final Time: " + CurrentTime.ToString());
            }

            // Are you bored to death?
            if (Boredom == 10)
            {
                Console.WriteLine("You're at your wit's end. You can't take it anymore.");
                Console.WriteLine("You knew today was doomed before your mom got off the phone. But you tried anyway.");
                Console.WriteLine("You retreat to your room for the rest of the day and lounge on your bed.");
                Console.WriteLine("Bertha has won. No matter what you do, her dullness and keen eye have thwarted you.");
                Console.WriteLine("Final Time: " + CurrentTime.ToString());
            }
        }
        #endregion

        #region CheckTime
        // Checks the time in the game and sets events in motion as needed.
        public void CheckTime()
        {
            TimeSpan two = new TimeSpan(2,0,0), three = new TimeSpan(3,0,0);
            TimeSpan four = new TimeSpan(4,0,0), five = new TimeSpan(5,0,0);
            TimeSpan six = new TimeSpan(6, 0, 0), seven = new TimeSpan(7,0,0);
        }
        #endregion
    }
}