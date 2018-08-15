using System.Collections.Generic;

namespace Yatzy.Evaluators
{
    /// <summary>
    /// Implementation of the "One pair" entry in Yatzy.
    /// </summary>
    public class OnePairEvaluator : IDiceEvaluator
    {
        /// <summary>
        /// The value of "One pair" is the
        /// highest sum of the values of two
        /// dice showing the same face, e.g. 5,5.
        /// </summary>
        public int Evaluate(Dictionary<int, int> diceCountByValue)
        {
            int score = 0;

            foreach (var dieCount in diceCountByValue)
            {
                int faceValue = dieCount.Key;
                int noOfDice = dieCount.Value;

                // If this is a pair (first condition)
                // with better score than seen so far (second condition)
                if ((noOfDice >= 2) && ((faceValue * 2) > score))
                {
                    score = faceValue * 2;
                }
            }

            return score;
        }
    }
}