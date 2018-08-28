namespace SWCClasses.Games.Dice
{
    public class Die
    {
        #region Instance fields
        private int _faceValue;
        private int _noOfSides;
        #endregion

        #region Constructor
        public Die(int noOfSides)
        {
            _noOfSides = noOfSides;
            Roll(); // This puts the die in a well-defined state
        }
        #endregion

        #region Properties
        public int FaceValue
        {
            get { return _faceValue; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Roll the die: the value will be set to a random number
        /// between 1 and _noOfSides (both included).
        /// </summary>
        public void Roll()
        {
            _faceValue = Numerics.RandomNumbers.Generate(1, _noOfSides);
        }
        #endregion        
    }
}