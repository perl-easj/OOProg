namespace Flinter
{
    /// <summary>
    /// This class represents a person profile,
    /// for instance for a dating website
    /// </summary>
    public class Profile
    {
        #region Enumeration definitions
        public enum Gender { Man, Woman }
        public enum EyeColor { Blue, Green, Red, Brown }
        public enum HairColor { White, Blond, Brown, Black, Grey }
        public enum HeightCategory { VeryShort, Short, Medium, Tall, VeryTall, Unknown }
        #endregion

        #region Instance fields
        private Gender _gender;
        private EyeColor _eyeColor;
        private HairColor _hairColor;
        private HeightCategory _heightCategory;
        #endregion

        #region Constructor
        public Profile(Gender gender, EyeColor eyeColor, HairColor hairColor, HeightCategory heightCategory)
        {
            _gender = gender;
            _eyeColor = eyeColor;
            _hairColor = hairColor;
            _heightCategory = heightCategory;
        }
        #endregion

        #region Properties
        public string Description
        {
            get
            {
                return $"You got a {_gender} with {_eyeColor} eyes and {_hairColor} hair, who is {_heightCategory}";
            }
        } 
        #endregion
    }
}