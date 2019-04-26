namespace WarlordsOfDraemor
{
    public class Village : Hub
    {
        public Village(string locName, string locDescription, bool hasBlacksmith, bool hasGeneralStore, bool hasWeaponsmith, bool canBuyHouse, bool canBuyShop)
    : base(locName, locDescription, hasBlacksmith, hasGeneralStore, hasWeaponsmith, canBuyHouse, canBuyShop)
        {
        }
    }
}
