using System.Collections.Generic;

namespace Yatzy.Evaluators.Straights
{
    /// <summary>
    /// Implementation of the "Big Straight" entry in Yatzy.
    /// </summary>
    public class BigStraightEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.SequenceScore(diceCountByFaceValue, 2, diceCountByFaceValue.Count);
        }
    }
}