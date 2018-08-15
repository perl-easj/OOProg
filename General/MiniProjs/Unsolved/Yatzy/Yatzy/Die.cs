using System;

namespace Yatzy
{
    /// <summary>
    /// This class represents a Die. The die has a number of faces,
    /// and can be "rolled" to generate a new face value, i.e. the 
    /// face which is now showing.
    /// </summary>
    public class Die
    {
        #region Instance fields
        private static Random _generator = new Random();

        private int _faceValue;
        private int _noOfFaces; 
        #endregion

        #region Constructor
        public Die(int noOfFaces)
        {
            _noOfFaces = noOfFaces;
            RollDie();
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Returns the value of the face currently showing
        /// </summary>
        public int FaceValue
        {
            get { return _faceValue; }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Rolls the dice to generate a new value.
        /// The value will be between 1 and the number of faces.
        /// </summary>
        public void RollDie()
        {
            _faceValue = _generator.Next(_noOfFaces) + 1;
        } 
        #endregion
    }
}