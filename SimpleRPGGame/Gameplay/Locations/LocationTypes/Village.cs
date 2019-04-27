namespace WarlordsOfDraemor
{
    public class Village : Hub
    {
        public Village(string locName, string locDescription, Tavern tavern, Blacksmith blacksmith, GeneralStore genStore, Weaponsmith weaponsmith, EmptyHouse emptyHouse, EmptyStore emptyStore)
    : base(locName, locDescription, tavern, blacksmith, genStore, weaponsmith, emptyHouse, emptyStore)
        {
        }
    }
}
