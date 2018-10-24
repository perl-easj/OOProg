using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class Weapon
    {
        public Weapon()
        {
            CharacterWeaponLeftNavigations = new HashSet<Character>();
            CharacterWeaponRightNavigations = new HashSet<Character>();
            Jewels = new HashSet<Jewel>();
        }

        public int Id { get; set; }
        public int WeaponModelId { get; set; }

        public WeaponModel WeaponModel { get; set; }
        public ICollection<Character> CharacterWeaponLeftNavigations { get; set; }
        public ICollection<Character> CharacterWeaponRightNavigations { get; set; }
        public ICollection<Jewel> Jewels { get; set; }
    }
}
