using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarlordsOfDraemor.Items;

namespace WarlordsOfDraemor.Gameplay
{
    static class Loot
    {
        static List<Item> gameLoot = new List<Item>()
        {
            // WEAPONS (Name, damage, rarity, value, weight)
            new Weapon("Rusty Iron Sword", 5, 0, 1, 3),
            new Weapon("Iron Sword", 7, 5, 5, 4),
            new Weapon("Rusty Steel Sword", 10, 15, 10, 5)

            // SHIELDS

            // LEG ARMORS

            // HELMETS
            
            // GAUNTLETS
            
            // CHEST ARMORS

            // POTIONS

            // BOOKS
        };
    }
}
