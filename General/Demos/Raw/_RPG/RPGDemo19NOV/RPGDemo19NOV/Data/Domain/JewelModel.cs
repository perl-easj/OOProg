using System;
using System.Collections.Generic;

namespace RPGDemo19NOV
{
    public partial class JewelModel
    {
        public JewelModel()
        {
            Jewels = new HashSet<Jewel>();
            WeaponJewelMatches = new HashSet<WeaponJewelMatch>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int RarityTierId { get; set; }
        public int BaseDamage { get; set; }

        public RarityTier RarityTier { get; set; }
        public ICollection<Jewel> Jewels { get; set; }
        public ICollection<WeaponJewelMatch> WeaponJewelMatches { get; set; }
    }
}
