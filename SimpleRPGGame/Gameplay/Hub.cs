using System;

namespace WarlordsOfDraemor
{
    public class Hub
    {
        private string hubName;
        public string hubLocation;
        private HubType hubType;
        private bool hasBlacksmith;
        private bool hasGeneralStore;
        private bool hasWeaponsmith;
        private bool hasHouseForSale;
        private bool hasStoreForSale;

        public Hub(string name, string location, HubType type, bool blacksmith, bool generalStore, bool weaponsmith, bool canBuyHouse, bool canBuyShop)
        {
            hubName = name;
            hubLocation = location;
            hubType = type;
            hasBlacksmith = blacksmith;
            hasGeneralStore = generalStore;
            hasWeaponsmith = weaponsmith;
            hasHouseForSale = canBuyHouse;
            hasStoreForSale = canBuyShop;
        }

        /// <summary>
        /// Sends the player to the Tavern, the main hub of the game.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Bool</returns>
        public bool GoToHub(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########################");
            Console.WriteLine($"The {hubType} of {hubName}");
            Console.WriteLine("##########################");
            Console.ResetColor();
            Console.WriteLine($"Welcome to the {hubType} of {hubName}, a {hubType} in Draemoor's {hubLocation}.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{hubType} Menu");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("Explore Draemor");
            Console.WriteLine("Visit the Tavern");
            if (hasGeneralStore) Console.WriteLine("Visit the General Store");
            if (hasWeaponsmith) Console.WriteLine("Visit the Weaponsmith");
            if (hasBlacksmith) Console.WriteLine("Visit the Blacksmith");
            if (hasHouseForSale) Console.WriteLine("Buy a House");
            if (hasStoreForSale) Console.WriteLine("Buy a Shop");
            Console.WriteLine("Retire from adventuring");
            Console.WriteLine();

            Console.Write("Please choose an option: ");
            string playerChoice = Console.ReadLine().ToLower();

            switch (playerChoice)
            {
                case "explore":
                    Exploration(player);
                    break;
                case "tavern":
                    JobBoard(player);
                    break;
                case "store":
                    Gossip(player);
                    break;
                case "weaponsmith":
                    GeneralStore(player);
                    break;
                case "blacksmith":
                    Weaponsmith(player);
                    break;
                case "buy a house":
                    BuyHouse(player);
                    break;
                case "buy a shop":
                    SetUpShop(player);
                    break;
                case "retire":
                    Console.Clear();
                    Console.WriteLine("Are you sure you want to quit? [Y/N]");
                    return false;
                default:
                    Console.WriteLine("Sorry, I didn't recognise that option!");
                    break;
            }

            return true;
        }

        private static void Blacksmith(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the blacksmith...");
            Console.ReadLine();
        }

        private static void Weaponsmith(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the weaponsmith...");
            Console.ReadLine();
        }

        private static void GeneralStore(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the General store...");
            Console.ReadLine();
        }

        private static void Gossip(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is where you will be able to gossip with the NPC's in the tavern...");
            Console.ReadLine();
        }

        private static void JobBoard(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is the job board, where you will discover quests and bounties...");
            Console.ReadLine();
        }

        private static void Exploration(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is where you will explore Draemor freely...");
            Console.ReadLine();
        }

        private static void BuyHouse(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is where you will be able to buy a house...");
            Console.ReadLine();
        }

        private static void SetUpShop(Player player)
        {
            Console.Clear();
            player.DisplayHeaderBar();
            Console.WriteLine("This is where you will be able to set up a shop in town to generate passive income...");
            Console.ReadLine();
        }

        public enum HubType
        {
            Inn,
            Village,
            Town,
            City
        }
    }
}
