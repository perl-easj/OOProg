using System;
using System.Collections.Generic;

namespace RPGDemo19NOV
{
    public partial class Character
    {
        public Character()
        {
            CharacterConfigs = new HashSet<CharacterConfig>();
            Weapons = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int Level { get; set; }

        public ICollection<CharacterConfig> CharacterConfigs { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
    }
}
