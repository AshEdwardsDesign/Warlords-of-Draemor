using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool DisplayStoreMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("###############");
            Console.WriteLine($"{GetType()}: {storeName}");
            Console.WriteLine("###############");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Welcome to {storeName}, owned by: {storeOwner.GetName()}");
            Console.WriteLine();

            // Store menu goes here
            Console.WriteLine("The store menu will go here");

            Console.ReadLine();

            return false;
        }
    }
}
