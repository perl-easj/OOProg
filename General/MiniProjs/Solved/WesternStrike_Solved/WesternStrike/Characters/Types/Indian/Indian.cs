using System.Collections.Generic;
using WesternStrike.Characters.Base;
using WesternStrike.Inventory.Types;

namespace WesternStrike.Characters.Types.Indian
{
    public class Indian : Character
    {
        public Indian(
            string name,
            double hitPoints,
            IndianInventory inventory,
            Dictionary<string, double> experticeMultiplier)
            : base(name, hitPoints, inventory, experticeMultiplier)
        {
        }
    }
}