namespace WarlordsOfDraemor
{
    public class Item
    {
        protected string name = "";
        protected int weight = 0;
        protected int value = 0;
        protected int rarity = 0;

        public Item(string itemName, int itemWeight, int itemValue, int itemRarity)
        {
            name = itemName;
            weight = itemWeight;
            value = itemValue;
            rarity = itemRarity;
        }

        public string getName()
        {
            return name;
        }

        public int getWeight()
        {
            return weight;
        }

        public int getValue()
        {
            return value;
        }

        public int getRarity()
        {
            return rarity;
        }
    }
}
