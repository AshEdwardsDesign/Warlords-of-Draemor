using System;
using System.Collections.Generic;
using System.Linq;

namespace WarlordsOfDraemor
{
    public static class TravelMenu
    {
        public static void DisplayTravelMenu(Player player)
        {
            bool invalidDest = true;

            while (invalidDest)
            {
                Console.Clear();
                Console.WriteLine("This is the travel menu.");
                Console.WriteLine($"Your current location: {player.GetLocation().GetName()}");
                Console.WriteLine();

                List<Location> allLocs = WorldLocations.GetAllLocations();

                int count = 1;

                foreach (Location loc in allLocs)
                {
                    Console.WriteLine($"{count}: {loc.GetName()} - {loc.GetType()}");
                    count++;
                }

                Console.WriteLine();
                Console.WriteLine("Where would you like to travel to?");

                string destination = Console.ReadLine().ToLower();
                Location chosenDest;

                if (destination == "exit" || destination == "quit")
                {
                    Program.MainMenu();
                }
                else if (allLocs.Where(i => i.GetName().ToLower() == destination).Count() != 0)
                {
                    chosenDest = allLocs.Where(i => i.GetName().ToLower() == destination).First();
                    invalidDest = false;
                    player.SetLocation(chosenDest);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, I don't recognise that destination. Please press enter to try again.");
                    Console.ResetColor();
                }
            }

            player.GetLocation().ShowLocationMenu(player);

        }
    }
}
