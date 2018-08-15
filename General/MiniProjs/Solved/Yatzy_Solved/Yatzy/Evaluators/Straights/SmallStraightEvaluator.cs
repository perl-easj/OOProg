using System.Collections.Generic;

namespace Yatzy.Evaluators.Straights
{
    /// <summary>
    /// Implementation of the "Small Straight" entry in Yatzy.
    /// </summary>
    public class SmallStraightEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.SequenceScore(diceCountByFaceValue, 1, diceCountByFaceValue.Count - 1);
        }
    }
}