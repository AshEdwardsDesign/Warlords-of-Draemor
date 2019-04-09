using System;

namespace WarlordsOfDraemor
{
    public static class Tavern
    {
        public static bool StartGame()
        {
            Player player = new Player();
            PlayIntro(player);
            bool cont = true;
            while (cont)
            {
                cont = GoToTavern(player);
            }
            return false;
        }

        public static void PlayIntro(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A JOURNEY BEGINS...");
            Console.ResetColor();
            Console.WriteLine("This is the intro, which will have you fight an enemy and overcome a puzzle before reaching the Fox & Hound.");
            Console.WriteLine("To be implemented.");
            Console.WriteLine("Combat test will start...");
            Console.ReadLine();
            Enemy enemy = new Enemy(player);
            Combat.StartCombat(player, enemy);
            Console.ReadLine();
        }

        /// <summary>
        /// Sends the player to the Tavern, the main hub of the game.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Bool</returns>
        public static bool GoToTavern(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########################");
            Console.WriteLine("THE FOX & HOUND: GAME HUB");
            Console.WriteLine("##########################");
            Console.ResetColor();
            Console.WriteLine("Welcome to the Fox & hound, a bustling inn which serves as the hub of all adventures throughout Draemor.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hub Menu");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("1. Explore Draemor");
            Console.WriteLine("2. Look at the job board");
            Console.WriteLine("3. Gossip");
            Console.WriteLine("4. Visit the General Store");
            Console.WriteLine("5. Visit the Weaponsmith");
            Console.WriteLine("6. Visit the Blacksmith");
            Console.WriteLine("7. Retire from adventuring");
            Console.WriteLine();

            Console.Write("Please choose an option: ");
            int playerChoice = int.Parse(Console.ReadLine());

            switch (playerChoice)
            {
                case 1:
                    Exploration(player);
                    break;
                case 2:
                    JobBoard(player);
                    break;
                case 3:
                    Gossip(player);
                    break;
                case 4:
                    GeneralStore(player);
                    break;
                case 5:
                    Weaponsmith(player);
                    break;
                case 6:
                    Blacksmith(player);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Are you sure you want to quit? [Y/N]");
                    return false;
                default:
                    Console.WriteLine("Sorry, I didn't recognise that option!");
                    break;
            }

            return true;
        }

        private static void Blacksmith(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the blacksmith...");
            Console.ReadLine();
        }

        private static void Weaponsmith(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the weaponsmith...");
            Console.ReadLine();
        }

        private static void GeneralStore(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the General store...");
            Console.ReadLine();
        }

        private static void Gossip(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is where you will be able to gossip with the NPC's in the tavern...");
            Console.ReadLine();
        }

        private static void JobBoard(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the job board, where you will discover quests and bounties...");
            Console.ReadLine();
        }

        private static void Exploration(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is where you will explore Draemor freely...");
            Console.ReadLine();
        }
    }
}
