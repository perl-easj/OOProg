using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class WeaponModel
    {
        public WeaponModel()
        {
            WeaponJewelMatches = new HashSet<WeaponJewelMatch>();
            Weapons = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int JewelSockets { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public string Rarity { get; set; }
        public int ItemLevel { get; set; }
        public bool TwoHanded { get; set; }

        public ICollection<WeaponJewelMatch> WeaponJewelMatches { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
    }
}
