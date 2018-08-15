using System.Collections.Generic;

namespace Yatzy.Evaluators.Pairs
{
    /// <summary>
    /// Implementation of the "Three Pairs" entry in Yatzy.
    /// </summary>
    public class ThreePairsEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { 2, 2, 2 });
        }
    }
}