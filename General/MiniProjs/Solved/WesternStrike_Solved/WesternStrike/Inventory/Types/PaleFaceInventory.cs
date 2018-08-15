using System.Collections.Generic;
using WesternStrike.Weapons.Types;

namespace WesternStrike.Inventory.Types
{
    public class PaleFaceInventory : Base.Inventory
    {
        public PaleFaceInventory() 
            : base(new Dictionary<WeaponType, int>
            {
                { WeaponType.Rifle, 2} ,
                { WeaponType.Gun, 2} ,
                { WeaponType.Knife, 3 }
            })
        {
        }
    }
}