using SimpleCraft.Spells;

namespace SimpleCraft.GUI
{
    public class UserInput
    {
        #region Instance fields
        private string _shortName;
        private int _x;
        private int _y;
        private bool _isValid;
        #endregion

        #region Constructor
        public UserInput(string rawUserInput)
        {
            // We try to decompose the raw user input into:
            // 1) A valid Spell short name
            // 2) A x-coordinate
            // 3) A y-coordinate

            _isValid = false;
            if (rawUserInput.Length == 3)
            {
                _shortName = rawUserInput.Substring(0, 1);
                if (SpellBook.SpellExists(_shortName))
                {
                    bool xOk = int.TryParse(rawUserInput.Substring(1, 1), out _x);
                    bool yOk = int.TryParse(rawUserInput.Substring(2, 1), out _y);

                    _isValid = xOk && yOk;
                }
            }
        }
        #endregion

        #region Properties
        public string ShortName
        {
            get { return _shortName; }
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public bool IsValid
        {
            get { return _isValid; }
        } 
        #endregion
    }
}