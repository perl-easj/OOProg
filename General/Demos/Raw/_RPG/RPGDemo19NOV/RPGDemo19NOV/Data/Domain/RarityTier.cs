using System;
using System.Collections.Generic;

namespace RPGDemo19NOV
{
    public partial class RarityTier
    {
        public RarityTier()
        {
            JewelModels = new HashSet<JewelModel>();
            WeaponModels = new HashSet<WeaponModel>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<JewelModel> JewelModels { get; set; }
        public ICollection<WeaponModel> WeaponModels { get; set; }
    }
}
