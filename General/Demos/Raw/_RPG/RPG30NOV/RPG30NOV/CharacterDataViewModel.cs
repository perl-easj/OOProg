namespace RPG30NOV
{
    public class CharacterDataViewModel
    {
        private Character _character;

        public CharacterDataViewModel(Character aCharacter)
        {
            _character = aCharacter;
        }

        public string NameText
        {
            get { return $"This is {_character.Name}"; }
        }

        public string WeaponText
        {
            get { return "The Weapon"; }
        }

        public int Id
        {
            get { return _character.Id; }
        }

        public override string ToString()
        {
            return $"{NameText}, owns {WeaponText}";
        }
    }
}