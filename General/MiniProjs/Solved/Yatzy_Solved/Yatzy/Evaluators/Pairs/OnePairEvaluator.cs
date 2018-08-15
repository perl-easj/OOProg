using System.Collections.Generic;

namespace Yatzy.Evaluators.Pairs
{
    /// <summary>
    /// Implementation of the "One Pair" entry in Yatzy.
    /// </summary>
    public class OnePairEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { 2 });
        }
    }
}