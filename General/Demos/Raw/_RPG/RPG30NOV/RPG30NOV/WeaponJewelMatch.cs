using System;
using System.Collections.Generic;

namespace RPG30NOV
{
    public partial class WeaponJewelMatch
    {
        public int Id { get; set; }
        public int JewelModelId { get; set; }
        public int WeaponModelId { get; set; }
        public double Factor { get; set; }

        public JewelModel JewelModel { get; set; }
        public WeaponModel WeaponModel { get; set; }
    }
}
