using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int HealthPoints { get; set; }
        public int? WeaponLeft { get; set; }
        public int? WeaponRight { get; set; }

        public Weapon WeaponLeftNavigation { get; set; }
        public Weapon WeaponRightNavigation { get; set; }
    }
}
