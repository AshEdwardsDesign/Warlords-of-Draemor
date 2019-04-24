namespace WarlordsOfDraemor
{
    public class Armor : Item
    {
        protected int armorRating = 0;

        public Armor(string itemName, int itemArmorRating, int itemRarity, int itemValue, int itemWeight) : base(itemName, itemRarity, itemValue, itemWeight)
        {
            armorRating = itemArmorRating;
        }
    }
}
