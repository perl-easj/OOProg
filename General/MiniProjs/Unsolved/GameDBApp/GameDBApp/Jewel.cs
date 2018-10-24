using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class Jewel
    {
        public int Id { get; set; }
        public int JewelModelId { get; set; }
        public int? WeaponId { get; set; }
        public string CutQuality { get; set; }

        public JewelCutQuality CutQualityNavigation { get; set; }
        public JewelModel JewelModel { get; set; }
        public Weapon Weapon { get; set; }
    }
}
