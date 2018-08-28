using System.Collections.Generic;

namespace SWCClasses.Games.Dice
{
    public class DiceCup
    {
        #region Instance fields
        private List<Die> _dice; 
        #endregion

        #region Constructor
        public DiceCup(int noOfDice, int noOfSides)
        {
            _dice = new List<Die>();
            for (int i = 0; i < noOfDice; i++)
            {
                _dice.Add(new Die(noOfSides));
            }
        } 
        #endregion

        #region Properties
        public int TotalValue
        {
            get
            {
                int sum = 0;
                foreach (Die d in _dice)
                {
                    sum = sum + d.FaceValue;
                }
                return sum;
            }
        }
        #endregion

        #region Methods
        public void Shake()
        {
            foreach (Die d in _dice)
            {
                d.Roll();
            }
        }
        #endregion
    }
}
