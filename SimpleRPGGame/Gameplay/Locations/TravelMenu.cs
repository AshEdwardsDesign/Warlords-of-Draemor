using System;
using System.Collections.Generic;
using System.Linq;

namespace WarlordsOfDraemor
{
    public static class TravelMenu
    {
        public static bool DisplayTravelMenu(Player player)
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

            bool invalidDest = true;

            while (invalidDest)
            {
                if (destination == "exit" || destination == "quit")
                {
                    return false;
                }
                else if (allLocs.Where(i => i.GetName().ToLower() == destination).Count() != 0)
                {
                    chosenDest = allLocs.Where(i => i.GetName().ToLower() == destination).First();
                    return player.SetLocation(chosenDest);
                }
                else
                {
                    Console.WriteLine("Sorry, I don't recognise that destination. Please try again.");
                    Console.ReadLine();
                }
            }

            return true;

        }
    }
}
