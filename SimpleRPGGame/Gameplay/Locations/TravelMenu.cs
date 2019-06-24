using System;
using System.Collections.Generic;
using System.Linq;

namespace WarlordsOfDraemor
{
    public static class TravelMenu
    {
        public static void DisplayTravelMenu(Player player)
        {
            // Clear the console and display the current location
            Console.Clear();
            Console.WriteLine("This is the travel menu.");
            Console.WriteLine($"Your current location: {player.GetLocation().GetName()}");
            Console.WriteLine();

            // Grab a list of all discovered locations
            List<Location> allLocs = player.getDiscoveredLocations();

            // Populate the travel screen with a numbered list of all discovered locations
            int count = 1;
            foreach (Location loc in allLocs)
            {
                Console.WriteLine($"{count}: {loc.GetName()} - {loc.GetType()}");
                count++;
            }
            Console.WriteLine($"{count}: Cancel");

            // Get the desired location from the player and store in the chosenDest variable
            Console.WriteLine();
            Console.WriteLine("Where would you like to travel to?");
            string destination = Console.ReadLine().ToLower();
            Location chosenDest;

            // If the player types exit or quit, go back to the main menu
            if (destination == "exit" || destination == "quit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ARE YOU SURE YOU WOULD LIKE TO QUIT [Y/N]? ");
                Console.ResetColor();
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Program.MainMenu();
                }
                else
                {
                    DisplayTravelMenu(player);
                }
            } // If the the player types cancel, take them back to the current location's menu
            else if (destination.ToLower() == "cancel")
            {
                player.GetLocation().ShowLocationMenu(player);
            } // If the the player types a known location in the world location list, take the player there
            else if (allLocs.Where(i => i.GetName().ToLower() == destination).Count() != 0)
            {
                chosenDest = allLocs.Where(i => i.GetName().ToLower() == destination).First();
                // Is the player already at the chosen location?
                if (chosenDest == player.GetLocation())
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"YOU ARE ALREADY AT {player.GetLocation().GetName().ToUpper()}");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                    DisplayTravelMenu(player);
                }
                else
                {
                    player.SetLocation(chosenDest);
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, I don't recognise that destination. Please any key to try again.");
                Console.ResetColor();
                Console.ReadKey();
                DisplayTravelMenu(player);
            }
        }
    }
}
