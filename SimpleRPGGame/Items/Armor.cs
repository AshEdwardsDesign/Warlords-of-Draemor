using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarlordsOfDraemor.Items
{
    public class Armor : Item
    {
        protected int armorRating = 0;

        public Armor(string itemName, int itemArmorRating, int itemRarity, int itemValue, int itemWeight)
        {
            name = itemName;
            armorRating = itemArmorRating;
            rarity = itemRarity;
            value = itemValue;
            weight = itemWeight;
        }
    }
}
