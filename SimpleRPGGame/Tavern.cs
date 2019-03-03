using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A JOURNEY BEGINS...");
            Console.ResetColor();
            Console.WriteLine("This is the intro, which will have you fight an enemy and overcome a puzzle before reaching the Fox & Hound.");
            Console.WriteLine("To be implemented.");
            Console.ReadLine();
        }

        public static bool GoToTavern(Player player)
        {
            Console.Clear();
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
                    Exploration();
                    break;
                case 2:
                    JobBoard();
                    break;
                case 3:
                    Gossip();
                    break;
                case 4:
                    GeneralStore();
                    break;
                case 5:
                    Weaponsmith();
                    break;
                case 6:
                    Blacksmith();
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

        private static void Blacksmith()
        {
            Console.Clear();
            Console.WriteLine("This is the blacksmith...");
            Console.ReadLine();
        }

        private static void Weaponsmith()
        {
            Console.Clear();
            Console.WriteLine("This is the weaponsmith...");
            Console.ReadLine();
        }

        private static void GeneralStore()
        {
            Console.Clear();
            Console.WriteLine("This is the General store...");
            Console.ReadLine();
        }

        private static void Gossip()
        {
            Console.Clear();
            Console.WriteLine("This is where you will be able to gossip with the NPC's in the tavern...");
            Console.ReadLine();
        }

        private static void JobBoard()
        {
            Console.Clear();
            Console.WriteLine("This is the job board, where you will discover quests and bounties...");
            Console.ReadLine();
        }

        private static void Exploration()
        {
            Console.Clear();
            Console.WriteLine("This is where you will explore Draemor freely...");
            Console.ReadLine();
        }
    }
}
