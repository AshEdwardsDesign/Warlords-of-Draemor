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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("###################");
            Console.WriteLine("WARLORDS OF DRAEMOR");
            Console.WriteLine("###################");
            Console.ResetColor();
            Console.WriteLine("Welcome to Warlords of Draemor; A text-based fantasy RPG.");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MAIN MENU");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Quit");

            Console.WriteLine();
            Console.Write("Please choose a number: ");
            string mainMenuChoice = Console.ReadLine();

            switch (mainMenuChoice)
            {
                case "1":
                    bool play = true;
                    while (play)
                    {
                        play = Tavern.StartGame();
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("THANK YOU FOR PLAYING! :)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please press enter to exit the application.");
                    Console.ResetColor();
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
