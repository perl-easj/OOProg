using System.Collections.Generic;

namespace Yatzy.Evaluators.Special
{
    /// <summary>
    /// Implementation of the "Chance" entry in Yatzy.
    /// </summary>
    public class ChanceEvaluator : IDiceEvaluator
    {
        /// <summary>
        /// The value of "Chance" is always
        /// just the simple sum of the dice
        /// </summary>
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            int score = 0;

            foreach (var dieCount in diceCountByFaceValue)
            {
                score = score + dieCount.Key * dieCount.Value;
            }

            return score;
        }
    }
}