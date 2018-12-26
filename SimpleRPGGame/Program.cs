using System;

namespace SimpleRPGGame
{
    partial class Program
    {
        static void Main(string[] args)
        {

            bool replay = true;

            while (replay)
                replay = MainMenu(); 

        }

        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("WARLORDS OF DRAEMOR");
            Console.WriteLine("Welcome to Warlords of Draemor; A text-based fantasy RPG, developed by Ash Edwards");

            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine();

            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Encyclopedia");
            Console.WriteLine("3. About");
            Console.WriteLine("4. Quit");

            Console.WriteLine();
            Console.Write("Please choose a number: ");
            string mainMenuChoice = Console.ReadLine();

            switch (mainMenuChoice)
            {
                case "1":
                    Character player = new Character();
                    player.NewCharacter();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("The game will now exit. Thank you for playing.");
                    Console.ReadLine();
                    return false;
                default:
                    Console.WriteLine("Sorry, I didn't recognise that option!");
                    break;
            }

            Console.ReadLine();
            return true;
        }
    }
}
