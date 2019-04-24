using System;
using System.Collections.Generic;
using System.Linq;

namespace WarlordsOfDraemor
{
    public static class Loot
    {
        public static List<Item> allGameLoot = new List<Item>()
        {
            // WEAPONS (Name, damage, rarity, value, weight)
            new Weapon("Rusty Iron Sword", 5, 0, 1, 3),
            new Weapon("Iron Sword", 7, 5, 5, 4),
            new Weapon("Rusty Steel Sword", 10, 15, 10, 5),
            new Weapon("Steel Sword", 15, 20, 15, 8),

            // SHIELDS (Name, defence, rarity, value, weight)
            new Shield("Hide Shield", 2, 5, 3, 5),
            new Shield("Iron Shield", 5, 8, 8, 10),
            new Shield("Steel Shield", 10, 15, 15, 13),
            new Shield("Shield of the Apocolypse", 50, 75, 250, 20),

            // LEG ARMORS

            // HELMETS
            
            // GAUNTLETS
            
            // CHEST ARMORS

            // POTIONS

            // BOOKS
        };

        public static List<Item> allWeapons = allGameLoot.Where(v => v.GetType() == typeof(Weapon)).ToList();
        public static List<Item> allShields = allGameLoot.Where(v => v.GetType() == typeof(Shield)).ToList();
        public static List<Item> allLegArmors = allGameLoot.Where(v => v.GetType() == typeof(LegArmor)).ToList();
        public static List<Item> allHelmets = allGameLoot.Where(v => v.GetType() == typeof(Helmet)).ToList();
        public static List<Item> allGauntlets = allGameLoot.Where(v => v.GetType() == typeof(Gauntlet)).ToList();
        public static List<Item> allChestArmors = allGameLoot.Where(v => v.GetType() == typeof(ChestArmor)).ToList();
        public static List<Item> allPotions = allGameLoot.Where(v => v.GetType() == typeof(Potion)).ToList();
        public static List<Item> allBooks = allGameLoot.Where(v => v.GetType() == typeof(Book)).ToList();

        /// <summary>
        /// Display the loot screen (showing loot, xp, gold gained etc).
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void DisplayLootScreen(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("############");
            Console.WriteLine("LOOT SCREEN");
            Console.WriteLine("############");
            Console.ResetColor();

            Console.WriteLine($"Player Name: {player.GetName()}\t\t\tEnemy Class: {enemy.GetEnemyClass()}");
            Console.WriteLine($"Player current health: {player.GetHealth()}");
            Console.WriteLine($"Gold: {player.GetGoldAmount()}\t\t\tPlayer xp: {player.GetXPAmount()}");
            Console.WriteLine();
            enemy.Death(player);
            Console.ReadLine();
        }
    }
}
