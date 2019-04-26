namespace WarlordsOfDraemor
{
    public class Town : Hub
    {
        public Town(string locName, string locDescription, bool hasBlacksmith, bool hasGeneralStore, bool hasWeaponsmith, bool canBuyHouse, bool canBuyShop)
    : base(locName, locDescription, hasBlacksmith, hasGeneralStore, hasWeaponsmith, canBuyHouse, canBuyShop)
        {
        }
    }
}
