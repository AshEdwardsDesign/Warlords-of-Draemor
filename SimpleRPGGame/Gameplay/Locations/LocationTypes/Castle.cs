namespace WarlordsOfDraemor
{
    public class Castle : Hub
    {
        public Castle(string locName, string locDescription, Blacksmith blacksmith, GeneralStore genStore, Weaponsmith weapon, EmptyHouse emptyHouse, EmptyStore emptyStore)
    : base(locName, locDescription, blacksmith, genStore, weapon, emptyHouse, emptyStore)
        {
        }
    }
}
