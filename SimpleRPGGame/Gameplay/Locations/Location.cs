using System;
using System.Collections.Generic;

namespace WarlordsOfDraemor
{
    public class Location
    {
        protected string locationName;
        protected string locationDescription;
        protected Exploration exploration;
        protected Tavern tavern;
        protected Blacksmith blacksmith;
        protected GeneralStore generalStore;
        protected Weaponsmith weaponsmith;
        protected EmptyHouse playerHouse;
        protected EmptyStore playerStore;

        public Location(string locName, string locDescription, Exploration areaToExplore = null)
        {
            locationName = locName;
            locationDescription = locDescription;
            exploration = areaToExplore;
        }

        /// <summary>
        /// Returns the location's name as a string.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return locationName;
        }

        /// <summary>
        /// Returns the locations description as a string.
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return locationDescription;
        }

        /// <summary>
        /// Displays the current locations' menu.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool ShowLocationMenu(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("###################");
            Console.WriteLine($"{GetName()}");
            Console.WriteLine("###################");
            Console.ResetColor();
            Console.WriteLine($"Welcome to {GetName()}. {GetDescription()}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{GetName()} Menu");
            Console.ResetColor();
            Console.WriteLine();

            // Menu populates here
            PopulateMenu();

            Console.Write("Where would you like to go? ");
            string playerChoice = Console.ReadLine().ToLower();

            return TriggerLocation(playerChoice, player);
        }

        private List<string> menuOptions = new List<string>() { };

        /// <summary>
        /// Populates the locations menu, based on the options available at the location.
        /// </summary>
        private void PopulateMenu()
        {
            menuOptions.Clear();
            if (GetType() == typeof(Cave) || GetType() == typeof(Dungeon) || GetType() == typeof(Forest))
            {
                menuOptions.Add("Explore this location");
            }

            if (tavern != null)
            {
                menuOptions.Add("Visit the Tavern");
            }

            if (blacksmith != null)
            {
                menuOptions.Add("Visit the Blacksmith");
            }

            if (weaponsmith != null)
            {
                menuOptions.Add("Visit the Weaponsmith");
            }

            if (generalStore != null)
            {
                menuOptions.Add("Visit the General Store");
            }

            if (playerHouse != null)
            {
                menuOptions.Add("Set up your own store");
            }

            if (playerStore != null)
            {
                menuOptions.Add("Buy a house");
            }

            menuOptions.Add("View the character menu");
            menuOptions.Add("Travel to another location");
            menuOptions.Add("Exit game");

            int count = 1;

            foreach (string item in menuOptions)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }

            // Add a space at the end of the menu
            Console.WriteLine();

        }

        private bool TriggerLocation(string choice, Player player)
        {
            // If player chooses to explore...
            if (choice == "explore")
            {
                if (exploration != null)
                {

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing to explore around here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to visit the tavern...
            if (choice == "tavern")
            {
                if (tavern != null)
                {
                    bool displayStore = true;

                    while (displayStore)
                    {
                        displayStore = tavern.DisplayStoreMenu();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There isn't a tavern here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to visit the blacksmith...
            if (choice == "blacksmith")
            {
                if (blacksmith != null)
                {
                    bool displayStore = true;

                    while (displayStore)
                    {
                        displayStore = blacksmith.DisplayStoreMenu();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There isn't a blacksmith here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to visit the weaponsmith...
            if (choice == "weaponsmith")
            {
                if (weaponsmith != null)
                {
                    bool displayStore = true;

                    while (displayStore)
                    {
                        displayStore = weaponsmith.DisplayStoreMenu();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There isn't a weaponsmith here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to visit the general store...
            if (choice == "general store")
            {
                if (generalStore != null)
                {
                    bool displayStore = true;

                    while (displayStore)
                    {
                        displayStore = generalStore.DisplayStoreMenu();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There isn't a general store here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to set up shop...
            if (choice == "store")
            {
                if (playerStore != null)
                {

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There isn't a store that you can buy here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to buy a house...
            if (choice == "house")
            {
                if (playerHouse != null)
                {

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There isn't a house that you can buy here.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            // If player chooses to travel...
            if (choice == "travel")
            {
                bool showTravelMenu = true;

                while (showTravelMenu)
                {
                    showTravelMenu = TravelMenu.DisplayTravelMenu(player);
                }
            }
            // If player chooses to view the character sheet...
            if (choice == "character")
            {
                bool showPlayerMenu = true;

                while (showPlayerMenu)
                {
                    showPlayerMenu = player.DisplayPlayerMenu();
                }
            }
            // If player chooses to exit...
            if (choice == "exit")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ARE YOU SURE YOU WANT TO EXIT [Y/N]? ");
                Console.ResetColor();
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "y")
                {
                    return false;
                }
            }
            return true;
        }

    }
}
