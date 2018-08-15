namespace Flinter
{
    /// <summary>
    /// This class represents a person profile,
    /// for instance for a dating website
    /// </summary>
    public class Profile
    {
        #region Instance fields
        private bool _gender;
        private string _eyeColor;
        private string _hairColor;
        private int _heightCategory;
        #endregion

        #region Constructor
        public Profile(bool gender, string eyeColor, string hairColor, int heightCategory)
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
                return $"You got a {GenderDescription} with {_eyeColor} eyes and {_hairColor} hair, who is {HeightDescription}";
            }
        }

        public string GenderDescription
        {
            get { return _gender ? "man" : "woman"; }
        }

        public string HeightDescription
        {
            get
            {
                switch (_heightCategory)
                {
                    case 0:
                        return "Very short";
                    case 1:
                        return "Short";
                    case 2:
                        return "Medium height";
                    case 3:
                        return "Tall";
                    case 4:
                        return "Very tall";
                    default:
                        return "Unknown height";
                }
            }
        } 
        #endregion
    }
}