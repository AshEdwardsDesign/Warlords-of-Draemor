using System;

namespace WarlordsOfDraemor
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            
            bool replay = true;

            while (replay)
                replay = MainMenu(); 

        }

        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("WARLORDS OF DRAEMOR");
            Console.WriteLine("Welcome to Warlords of Draemor; A text-based fantasy RPG, developed by Ash Edwards");

            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine();

            Console.WriteLine("1. New Game");
            Console.WriteLine("2. About");
            Console.WriteLine("3. Quit");

            Console.WriteLine();
            Console.Write("Please choose a number: ");
            string mainMenuChoice = Console.ReadLine();

            switch (mainMenuChoice)
            {
                case "1":
                    // StartGame();
                    Console.Clear();
                    Console.WriteLine("This is where a new game would start!");
                    Console.ReadLine();
                    break;
                case "2":
                    AboutPage();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("The game will now exit. Thank you for playing.");
                    Console.ReadLine();
                    return false;
                default:
                    Console.WriteLine("Sorry, I didn't recognise that option!");
                    break;
            }
            
            return true;
        }
    }
}
