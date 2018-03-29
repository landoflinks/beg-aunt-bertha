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

        #region Television
        // This method details how successful the player is with watching TV.
        public void Television()
        {
            TimeSpan fifteen = new TimeSpan(0, 15, 0);
            TimeSpan thirty = new TimeSpan(0, 30, 0);
            TimeSpan oneHour = new TimeSpan(1, 0, 0);
            int tvNum;
            Random rand = new Random();
            tvNum = rand.Next(1, 6);

            switch (tvNum)
            {
                case 1:
                    Console.WriteLine("Surprisingly, Bertha lets you have the TV remote for half an hour.");
                    Console.WriteLine("You think this good will could be because none of her shows are on, but you roll with it.");
                    Boredom -= 1;
                    CurrentTime = CurrentTime.Add(thirty);
                    break;
                case 2:
                    Console.WriteLine("Bertha allows you to watch TV, but she forces you to watch stale old sitcoms from the seventies.");
                    Boredom += 2;
                    CurrentTime = CurrentTime.Add(thirty);
                    break;
                case 3:
                    Console.WriteLine("Bertha is on the phone with a good friend, so you get the TV to yourself for an hour.");
                    Boredom -= 2;
                    CurrentTime = CurrentTime.Add(oneHour);
                    break;
                case 4:
                    Console.WriteLine("Aunt Bertha reluctantly lets you watch TV, then steals the remote again a few minutes later.");
                    Console.WriteLine("Apparently she doesn't approve of Spongebob.");
                    Boredom += 1;
                    CurrentTime = CurrentTime.Add(fifteen);
                    break;
                case 5:
                    Console.WriteLine("Aunt Bertha is in the middle of a soap opera, so she won't let you even breathe on the remote.");
                    Boredom += 1;
                    break;
                case 6:
                    Console.WriteLine("You attempt to watch a TV movie on Hallmark, thinking that Aunt Bertha will approve. She doesn't.");
                    Boredom += 1;
                    CurrentTime = CurrentTime.Add(fifteen);
                    break;
            }
        }
        #endregion

        #region DieFromBoredom
        // This is the method that handles the laziest option, sitting around bored.
        public void DieFromBoredom()
        {
            Console.WriteLine("Really? Really?! REALLY?!");
            Console.WriteLine("Come on! This is your first day of summer vacation!");
            Console.WriteLine("You can't roll over and let Bertha win this easily!");
            Console.WriteLine("Get out there and salvage what you can of this day!");
            Boredom += 1;
            CurrentTime = CurrentTime.Add(new TimeSpan(0, 15, 0));
        }
        #endregion

        #region VideoGames
        /* This method handles the player's attempts to play video games.
        Some of the results will depend on what Bertha is currently doing.
        This method relies on randoms, but uses larger numbers akin to dice rolls. */
        public void VideoGames()
        {
            TimeSpan fifteen = new TimeSpan(0, 15, 0);
            TimeSpan thirty = new TimeSpan(0, 30, 0);
            TimeSpan oneHour = new TimeSpan(1, 0, 0);
            int videoNum, answer;
            Random rand = new Random();
            videoNum = rand.Next(1, 4);

            Console.WriteLine("Bertha's current status: " + BerthaStatus);

            Console.WriteLine("Choose one of the following gaming sources: 1 - TV, 2 - Computer, 3 - Handheld, 4 - Phone/Mobile");
            Console.Write("Enter in a value: ");
            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1: // TV - Depends on if Bertha is using it.
                    if (BerthaStatus == "Watching TV" || BerthaStatus == "Bawling her eyes out over a predictable soap opera twist") 
                    {
                        Console.WriteLine("You try to boot up the game system hooked to the TV, but Aunt Bertha won't let you.");
                        Console.WriteLine("For the time being, Bertha has taken over the television.");
                        Anger += 1;
                        Boredom += 1;
                    }
                    else
                    {
                        Console.WriteLine("The only decent TV in the house is in your family's living room.");
                        switch (videoNum)
                        {
                            case 1:
                                Console.WriteLine("You snuck in fifteen minutes of game time before you were caught. Not much, but it'll do for now.");
                                Anger += 1;
                                Boredom -= 1;
                                CurrentTime = CurrentTime.Add(fifteen);
                                break;
                            case 2:
                                Console.WriteLine("You turn on your game system only to find Bertha behind you.");
                                Console.WriteLine("She turns it off and scolds you about too much screen time.");
                                Boredom += 1;
                                Anger += 1;
                                CurrentTime = CurrentTime.Add(fifteen);
                                break;
                            case 3:
                                Console.WriteLine("Bertha is outside taking care of your cat. Somehow it got stuck in a tree.");
                                Console.WriteLine("You have absolutely NO IDEA how an indoor cat wound up in a tree outdoors. None at all.");
                                Console.WriteLine("For now, you're going to spend some time in front of YOUR television.");
                                Boredom -= 2;
                                Anger += 1;
                                CurrentTime = CurrentTime.Add(thirty);
                                break;
                            case 4:
                                Console.WriteLine("Bertha surprisingly let you boot up a game, but takes back that privilege a minute later.");
                                Console.WriteLine("She dislikes the title of what is suggestively a 'violent' game.");
                                Anger += 2;
                                Boredom += 1;
                                break;
                        }
                    }
                    break;
                case 2: // Computer - Depends on if Bertha is using it.
                    if (BerthaStatus == "Checking Facebook on mom's computer")
                    {
                        Console.WriteLine("You attempt to get onto your mom's computer to play games, but Bertha is hogging it.");
                        Console.WriteLine("You just hope that she doesn't somehow delete everything. She's not very tech-savvy.");
                        Anger += 1;
                        Boredom += 1;
                    }
                    else
                    {
                        Console.WriteLine("There sits mom's computer, in all of it's wonderful, mid-end glory.");
                        switch (videoNum)
                        {
                            case 1:
                                Console.WriteLine("The computer doesn't really want to work correctly today. You wonder if Bertha did something...");
                                Console.WriteLine("You spend a few minutes fiddling around with it until you give up.");
                                Boredom += 2;
                                CurrentTime = CurrentTime.Add(fifteen);
                                break;
                            case 2:
                                Console.WriteLine("You're able to secure an hour of precious computer time while Bertha chews out her ex on the phone.");
                                Boredom -= 2;
                                Anger += 2;
                                CurrentTime = CurrentTime.Add(oneHour);
                                break;
                            case 3:
                                Console.WriteLine("Bertha catches you trying to use the computer.");
                                Console.WriteLine("Surprisingly, your aren't kicked off. Instead, she makes you watch educational vidoes for little kids. Boring!");
                                Boredom += 1;
                                Anger -= 1;
                                CurrentTime = CurrentTime.Add(thirty);
                                break;
                            case 4:
                                Console.WriteLine("You successfully convince Aunt Bertha to let you play a 'harmless' game.");
                                Console.WriteLine("You switch to the REAL game while she isn't looking. Unfortunately, she realizes her mistake.");
                                Boredom -= 1;
                                Anger += 1;
                                CurrentTime = CurrentTime.Add(thirty);
                                break;
                        }
                    }
                    break;
                case 3: // Make sure Bertha doesn't catch you!
                    Console.WriteLine("Ah, time for the trusty handheld that you picked up last year.");
                    switch (videoNum)
                    {
                        case 1:
                            Console.WriteLine("You pull out your handheld, then realize Bertha is standing behind you.");
                            Console.WriteLine("You quickly lie and tell her that it's an 'educational' device.");
                            Console.WriteLine("To convince her, you play a meh-ish pet sim that was on sale for a little while.");
                            Anger -= 1;
                            Boredom += 1;
                            CurrentTime = CurrentTime.Add(thirty);
                            break;
                        case 2:
                            Console.WriteLine("You try to play your handheld, but then realize that it needs charged badly.");
                            Console.WriteLine("You can't find the main charger, so you suspect you left it on the couch where Bertha is.");
                            Console.WriteLine("You loaned your spare charger to a friend while she's on vacation.");
                            Boredom += 1;
                            break;
                        case 3:
                            Console.WriteLine("You sneak off to your room and get a good gaming session in under your bed.");
                            Console.WriteLine("Bertha soon finds you and is furious, having believed you 'snuck out'.");
                            Anger += 2;
                            Boredom -= 2;
                            CurrentTime = CurrentTime.Add(oneHour);
                            break;
                        case 4:
                            Console.WriteLine("You pull out your handheld and start playing your favorite game for the device.");
                            Console.WriteLine("Bertha grabs it out of your hands after a few minutes and asks what kind of 'phone' it is.");
                            Console.WriteLine("After you explain, she confiscates the device in a very accessible place...Hmmmmm....");
                            Anger += 1;
                            Boredom -= 1;
                            CurrentTime = CurrentTime.Add(fifteen);
                            break;
                    }
                    break;
                case 4: // Your personal device. Bertha can limit your time with it.
                    break;
            }
        }
        #endregion
        #endregion
    }
}
