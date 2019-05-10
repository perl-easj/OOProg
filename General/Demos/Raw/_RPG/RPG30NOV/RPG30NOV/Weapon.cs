using System;
using System.Collections.Generic;

namespace RPG30NOV
{
    public partial class Weapon
    {
        public Weapon()
        {
            CharacterConfigWeaponIdLeftNavigations = new HashSet<CharacterConfig>();
            CharacterConfigWeaponIdRightNavigations = new HashSet<CharacterConfig>();
            Jewels = new HashSet<Jewel>();
        }

        public int Id { get; set; }
        public int WeaponModelId { get; set; }
        public int? CharacterId { get; set; }

        public Character Character { get; set; }
        public WeaponModel WeaponModel { get; set; }
        public ICollection<CharacterConfig> CharacterConfigWeaponIdLeftNavigations { get; set; }
        public ICollection<CharacterConfig> CharacterConfigWeaponIdRightNavigations { get; set; }
        public ICollection<Jewel> Jewels { get; set; }
    }
}
