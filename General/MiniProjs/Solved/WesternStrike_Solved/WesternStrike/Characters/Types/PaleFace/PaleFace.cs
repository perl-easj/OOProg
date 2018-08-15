using System.Collections.Generic;
using WesternStrike.Characters.Base;
using WesternStrike.Inventory.Types;

namespace WesternStrike.Characters.Types.PaleFace
{
    public class PaleFace : Character
    {
        public PaleFace(
            string name, 
            double hitPoints,
            PaleFaceInventory inventory,
            Dictionary<string, double> experticeMultiplier)
        : base(name, hitPoints, inventory, experticeMultiplier)
        {
        }
    }
}