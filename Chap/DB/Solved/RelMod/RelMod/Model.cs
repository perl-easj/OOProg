using System.Collections.Generic;

namespace RelMod
{
    public class Model
    {
        private Dictionary<int, Weapon> _weapons;
        private Dictionary<int, Character> _characters;

        public Model()
        {
            _weapons = new Dictionary<int, Weapon>();
            _characters = new Dictionary<int, Character>();
        }

        public void AddWeapon(Weapon aWeapon)
        {
            ValidateWeapon(aWeapon);
            _weapons.Add(aWeapon.Id, aWeapon);
        }

        public void AddCharacter(Character aCharacter)
        {
            ValidateCharacter(aCharacter);
            _characters.Add(aCharacter.Id, aCharacter);
        }

        private void ValidateWeapon(Weapon aWeapon)
        {
            // Check all constraints on instance fields
            // (or do this in specific classes?)
        }

        private void ValidateCharacter(Character aCharacter)
        {
            // Check all constraints on instance fields
            // (or do this in specific classes?)
        }
    }
}