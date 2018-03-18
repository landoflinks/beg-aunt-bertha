using System;

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
                        TimeSpan fifteen = new TimeSpan(0, 15, 0);
                        TimeSpan thirty = new TimeSpan(0, 30, 0);
                        TimeSpan oneHour = new TimeSpan(1, 0, 0);
                        int outsideNum;
                        Random rand = new Random();
                        outsideNum = rand.Next(1, 8);

                        switch (outsideNum)
                        {
                            case 1:
                                Console.WriteLine("You find a stick and draw pictures in the dirt. Boring!");
                                Boredom += 1;
                                CurrentTime = CurrentTime.Add(fifteen);
                                break;
                            case 2:
                                Console.WriteLine("You play catch with the neighbor's dog. It's kinda fun minus the slobber.");
                                Boredom -= 1;
                                CurrentTime = CurrentTime.Add(thirty);
                                break;
                            case 3:
                                Console.WriteLine("You stare at patterns in the clouds.");
                                Boredom -= 1;
                                CurrentTime = CurrentTime.Add(fifteen);
                        break;
                            case 4:
                                Console.WriteLine("You get together with some of the neighborhood kids and play a sport you like in a park across the street.");
                                Boredom -= 2;
                                CurrentTime = CurrentTime.Add(oneHour);
                        break;
                            case 5:
                                Console.WriteLine("You play a sport with some of the neighborhood kids across the street, but you secretly hate it.");
                                Boredom += 2;
                                CurrentTime = CurrentTime.Add(oneHour);
                                break;
                            case 6:
                                Console.WriteLine("You grab your skateboard for some sidewalk surfing action, but Aunt Bertha confiscates it.");
                                Anger += 1;
                                Boredom += 1;
                                break;
                            case 7:
                                Console.WriteLine("You and the neighbor kid start playing on your swing set, but Aunt Bertha appears.");
                                Console.WriteLine("She complains that you've been playing too loudly and sends the poor kid home.");
                                Anger += 1;
                                Boredom += 1;
                                break;
                            case 8:
                                Console.WriteLine("You attempt to play with your cat, but she isn't in a good mood. Ouch!");
                                Boredom += 1;
                                break;
                            case 9:
                                Console.WriteLine("You sneak over to a neighbor kid's house and play video games for as long as you dare.");
                                Boredom -= 3;
                                CurrentTime = CurrentTime.Add(oneHour);
                                break;
                }
                    }
                    
             }
        #endregion

        #region Read
        // This method details how reading went for the player.
        public void Read()
        {
            TimeSpan thirty = new TimeSpan(0, 30, 0);
            TimeSpan oneHour = new TimeSpan(1, 0, 0);
            int readNum;
            Random rand = new Random();
            readNum = rand.Next(1, 4);

            switch (readNum)
            {
                case 1:
                    Console.WriteLine("You go back to your room and look through some comics for a bit. Bertha doesn't approve.");
                    Boredom -= 1;
                    Anger += 1;
                    CurrentTime = CurrentTime.Add(thirty);
                    break;
                case 2:
                    Console.WriteLine("You mention to Bertha that you're going to read, and she shoves a book into your hands.");
                    Console.WriteLine("Now, you've read some classic novels that aren't bad at all, but this one is downright BORING.");
                    Boredom += 2;
                    CurrentTime = CurrentTime.Add(oneHour);
                    break;
                case 3:
                    Console.WriteLine("You go to your room and pull a book from your shelf. You've read it about fifty times.");
                    CurrentTime = CurrentTime.Add(oneHour);
                    break;
                case 4:
                    Console.WriteLine("Since Bertha won't let you PLAY games, you go to your room and read through game MANUALS.");
                    Boredom -= 1;
                    CurrentTime = CurrentTime.Add(thirty);
                    break;
            }
        }

        #endregion
        #endregion
    }
}
