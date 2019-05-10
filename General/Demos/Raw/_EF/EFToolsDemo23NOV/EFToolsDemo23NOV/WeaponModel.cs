using System;
using System.Collections.Generic;

namespace EFToolsDemo23NOV
{
    public partial class WeaponModel
    {
        public WeaponModel()
        {
            WeaponJewelMatches = new HashSet<WeaponJewelMatch>();
            Weapons = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int WeaponTypeId { get; set; }
        public int RarityTierId { get; set; }
        public int JewelSockets { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public RarityTier RarityTier { get; set; }
        public WeaponType WeaponType { get; set; }
        public ICollection<WeaponJewelMatch> WeaponJewelMatches { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
    }
}
