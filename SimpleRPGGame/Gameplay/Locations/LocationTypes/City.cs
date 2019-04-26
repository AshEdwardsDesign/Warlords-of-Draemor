namespace WarlordsOfDraemor
{
    public class City : Hub
    {
        public City(string locName, string locDescription, bool hasBlacksmith, bool hasGeneralStore, bool hasWeaponsmith, bool canBuyHouse, bool canBuyShop)
    : base(locName, locDescription, hasBlacksmith, hasGeneralStore, hasWeaponsmith, canBuyHouse, canBuyShop)
        {
        }
    }
}
