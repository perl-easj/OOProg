using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class JewelModel
    {
        public JewelModel()
        {
            Jewels = new HashSet<Jewel>();
            WeaponJewelMatches = new HashSet<WeaponJewelMatch>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public int AddedDamage { get; set; }

        public ICollection<Jewel> Jewels { get; set; }
        public ICollection<WeaponJewelMatch> WeaponJewelMatches { get; set; }
    }
}
