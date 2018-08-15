using System.Collections.Generic;
using WesternStrike.Weapons.Types;

namespace WesternStrike.Inventory.Types
{
    public class IndianInventory : Base.Inventory
    {
        public IndianInventory()
            : base(new Dictionary<WeaponType, int>
            {
                { WeaponType.Rifle, 2} ,
                { WeaponType.Bow, 2 } ,
                { WeaponType.Axe, 3 } ,
                { WeaponType.Gun, 1 }
            })
        {
        }
    }
}