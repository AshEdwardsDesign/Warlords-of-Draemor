namespace WarlordsOfDraemor
{
    public class Weapon : Item
    {
        private int damage = 0;

        /// <summary>
        /// Weapon constructer to create a new weapon.
        /// </summary>
        /// <param name="itemName">This is the name of the item.</param>
        /// <param name="itemDamage"></param>
        /// <param name="itemRarity"></param>
        /// <param name="itemValue"></param>
        /// <param name="itemWeight"></param>
        public Weapon(string itemName, int itemDamage, int itemRarity, int itemValue, int itemWeight) : base(itemName,itemWeight,itemValue,itemRarity)
        {
            name = itemName;
            damage = itemDamage;
            rarity = itemRarity;
            value = itemValue;
            weight = itemWeight;
        }
    }
}
