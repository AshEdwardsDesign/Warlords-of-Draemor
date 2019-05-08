using System;

namespace WarlordsOfDraemor
{
    public class Store
    {
        protected string storeName;
        protected string storeDescription;
        protected NPC storeOwner;

        public Store(string name, string description, NPC owner)
        {
            storeName = name;
            storeDescription = description;
            storeOwner = owner;
        }

        public void DisplayStoreMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("###############");
            Console.WriteLine($"{GetType().Name}: {storeName}");
            Console.WriteLine("###############");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Welcome to {storeName}, owned by: {storeOwner.GetName()}");
            Console.WriteLine();

            // Store menu goes here
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("STORE MENU");
            Console.ResetColor();

            Console.WriteLine("1. Talk to the store owner");
            Console.WriteLine("2. Buy");
            Console.WriteLine("3. Sell");
            Console.WriteLine("4. Purchase the store");
            Console.WriteLine("5. Leave");

            // Get player input
            Console.WriteLine();
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine().ToLower();

            // Parse the player input
            if (choice == "talk")
            {

            } else if (choice == "buy")
            {

            }


            
        }
    }
}
