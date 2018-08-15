using System;

namespace Yatzy
{
    /// <summary>
    /// This class represents a Die. The die has a number of faces,
    /// and can be "rolled" to generate a new value, i.e. the face
    /// which is now showing.
    /// </summary>
    public class Die
    {
        private static Random _generator = new Random();

        private int _value;
        private int _noOfFaces;

        public Die(int noOfFaces)
        {
            _noOfFaces = noOfFaces;
            RollDie();
        }

        /// <summary>
        /// Rolls the dice to generate a new value.
        /// The value will be between 1 and the number of faces.
        /// </summary>
        public void RollDie()
        {
            _value = _generator.Next(_noOfFaces) + 1;
        }

        /// <summary>
        /// Returns the value of the face currently showing
        /// </summary>
        public int Value
        {
            get { return _value; }
        }
    }
}