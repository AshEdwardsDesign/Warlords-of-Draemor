namespace WarlordsOfDraemor
{
    public class Armor : Item
    {
        protected int defence = 0;

        public Armor(string itemName, int itemArmorRating, int itemRarity, int itemValue, int itemWeight) : base(itemName, itemRarity, itemValue, itemWeight)
        {
            defence = itemArmorRating;
        }

        public int GetArmorRating()
        {
            return defence;
        }
    }
}
