using System;

namespace WarlordsOfDraemor
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
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
                    NewGameStart.StartGame();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("THANK YOU FOR PLAYING! :)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please press enter to exit the application.");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, I didn't recognise that option!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
    }
}
