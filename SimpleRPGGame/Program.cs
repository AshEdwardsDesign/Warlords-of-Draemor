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
            UI.DisplayTitle("WARLORDS OF DRAEMOR");
            UI.DisplaySubTitle("Welcome to Warlords of Draemor; A text-based fantasy RPG.");

            Console.WriteLine();
            UI.DisplayTitle("MAIN MENU");
            Console.WriteLine();

            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Quit");
            Console.WriteLine();

            UI.DisplayNoticeText("Please choose a number: ");
            string mainMenuChoice = Console.ReadLine();

            switch (mainMenuChoice)
            {
                case "1":
                    NewGameStart.StartGame();
                    break;
                case "2":
                    Console.Clear();
                    UI.DisplaySuccessText("THANK YOU FOR PLAYING! :)");
                    UI.DisplayNoticeText("Please press enter to exit the application.");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine();
                    UI.DisplayWarningText("Sorry, I didn't recognise that option!");
                    UI.DisplayInputText("Press any key to try again.");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
        }
    }
}
