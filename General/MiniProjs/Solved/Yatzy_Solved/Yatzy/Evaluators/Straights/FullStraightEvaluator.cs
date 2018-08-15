using System.Collections.Generic;

namespace Yatzy.Evaluators.Straights
{
    /// <summary>
    /// Implementation of the "Full Straight" entry in Yatzy.
    /// </summary>
    public class FullStraightEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.SequenceScore(diceCountByFaceValue, 1, diceCountByFaceValue.Count);
        }     
    }
}