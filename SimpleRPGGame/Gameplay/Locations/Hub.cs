using System;

namespace WarlordsOfDraemor
{
    public class Hub : Location
    {
        public Hub(string locName, string locDescription, Tavern tav = null, Blacksmith smith = null, GeneralStore genStore = null, Weaponsmith weapon = null, EmptyHouse house = null, EmptyStore store = null) : base(locName, locDescription)
        {
            locationName = locName;
            locationDescription = locDescription;
            tavern = tav;
            blacksmith = smith;
            generalStore = genStore;
            weaponsmith = weapon;
            playerHouse = house;
            playerStore = store;
        }
    }
}
