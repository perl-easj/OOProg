using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class WeaponJewelMatch
    {
        public int WeaponModelId { get; set; }
        public int JewelModelId { get; set; }
        public double MatchFactor { get; set; }

        public JewelModel JewelModel { get; set; }
        public WeaponModel WeaponModel { get; set; }
    }
}
