namespace WarlordsOfDraemor
{
    public class Inn : Hub
    {
        public Inn(string locName, string locDescription, bool hasBlacksmith, bool hasGeneralStore, bool hasWeaponsmith, bool canBuyHouse, bool canBuyShop)
            : base(locName, locDescription, hasBlacksmith, hasGeneralStore, hasWeaponsmith, canBuyHouse, canBuyShop)
        {
        }
    }
}
